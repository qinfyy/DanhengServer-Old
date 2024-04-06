using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Database.Scene;
using EggLink.DanhengServer.Database.Tutorial;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Enums.Scene;
using EggLink.DanhengServer.Game.Avatar;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Game.Gacha;
using EggLink.DanhengServer.Game.Inventory;
using EggLink.DanhengServer.Game.Lineup;
using EggLink.DanhengServer.Game.Message;
using EggLink.DanhengServer.Game.Mission;
using EggLink.DanhengServer.Game.Rogue;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Game.Shop;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server;
using EggLink.DanhengServer.Server.Packet;
using EggLink.DanhengServer.Server.Packet.Send.Lineup;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using EggLink.DanhengServer.Server.Packet.Send.Scene;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Player
{
    public class PlayerInstance(PlayerData data)
    {
        #region Managers

        public AvatarManager? AvatarManager { get; private set; }
        public LineupManager? LineupManager { get; private set; }
        public InventoryManager? InventoryManager { get; private set; }
        public BattleManager? BattleManager { get; private set; }
        public BattleInstance? BattleInstance { get; set; }
        public MissionManager? MissionManager { get; private set; }
        public GachaManager? GachaManager { get; private set; }
        public MessageManager? MessageManager { get; private set; }
        public RogueManager? RogueManager { get; private set; }
        public ShopService? ShopService { get; private set; }

        #endregion

        #region Datas

        public PlayerData Data { get; set; } = data;
        public PlayerUnlockData? PlayerUnlockData { get; private set; }
        public SceneData? SceneData { get; private set; }
        public TutorialData? TutorialData { get; private set; }
        public TutorialGuideData? TutorialGuideData { get; private set; }
        public SceneInstance? SceneInstance { get; private set; }
        public ushort Uid { get; set; }
        public Connection? Connection { get; set; }
        public bool Initialized { get; set; } = false;
        public bool IsNewPlayer { get; set; } = false;
        public int NextBattleId { get; set; } = 0;

        #endregion

        #region Initializers

        public PlayerInstance(int uid) : this(new PlayerData() { Uid = uid })
        {
            // new player
            IsNewPlayer = true;
            DatabaseHelper.Instance?.SaveInstance(Data);

            InitialPlayerManager();

            AddAvatar(8001);
            AddAvatar(1001);
            LineupManager?.AddSpecialAvatarToCurTeam(10010050);

            MissionManager!.AcceptMainMission(1000101);

            Initialized = true;
        }

        private void InitialPlayerManager()
        {
            Uid = (ushort)Data.Uid;
            AvatarManager = new(this);
            LineupManager = new(this);
            InventoryManager = new(this);
            BattleManager = new(this);
            MissionManager = new(this);
            GachaManager = new(this);
            MessageManager = new(this);
            RogueManager = new(this);
            ShopService = new(this);

            PlayerUnlockData = InitializeDatabase<PlayerUnlockData>();
            SceneData = InitializeDatabase<SceneData>();
            TutorialData = InitializeDatabase<TutorialData>();
            TutorialGuideData = InitializeDatabase<TutorialGuideData>();

            Data.LastActiveTime = Extensions.GetUnixSec();
            DatabaseHelper.Instance?.UpdateInstance(Data);

            LoadScene(Data.PlaneId, Data.FloorId, Data.EntryId, Data.Pos!, Data.Rot!, false);
            if (SceneInstance == null)
            {
                EnterScene(2000101, 0, false);
            }

            if (LineupManager!.GetCurLineup()!.IsExtraLineup())
            {
                LineupManager!.SetCurLineup(0);
            }
        }

        public T? InitializeDatabase<T>() where T : class, new()
        {
            if (new T() is BaseDatabaseData database)
            {
                var instance = DatabaseHelper.Instance?.GetInstance<T>(Uid);
                if (instance == null)
                {
                    database.Uid = Uid;
                    DatabaseHelper.Instance?.SaveInstance<T>((database as T)!);
                    instance = DatabaseHelper.Instance?.GetInstance<T>(Uid);
                }
                return instance!;
            }
            return null;
        }

        #endregion

        #region Network
        public void OnLogin()
        {
            if (!Initialized)
            {
                InitialPlayerManager();
            }
            
            SendPacket(new PacketStaminaInfoScNotify(this));

        }

        public void OnLogoutAsync()
        {
            try
            {
                DatabaseHelper.Instance?.UpdateInstance(LineupManager!.LineupData);
                DatabaseHelper.Instance?.UpdateInstance(InventoryManager!.Data);
                DatabaseHelper.Instance?.UpdateInstance(MissionManager!.Data);
                DatabaseHelper.Instance?.UpdateInstance(AvatarManager!.AvatarData!);
                DatabaseHelper.Instance?.UpdateInstance(GachaManager!.GachaData!);
                DatabaseHelper.Instance?.UpdateInstance(Data);
                DatabaseHelper.Instance?.UpdateInstance(PlayerUnlockData!);
                DatabaseHelper.Instance?.UpdateInstance(SceneData!);
                DatabaseHelper.Instance?.UpdateInstance(TutorialData!);
            } catch
            {
            }
        }

        public void SendPacket(BasePacket packet)
        {
            Connection?.SendPacket(packet);
        }
        #endregion

        #region Actions

        public void AddAvatar(int avatarId)
        {
            AvatarManager?.AddAvatar(avatarId);
        }

        public void SpendStamina(int staminaCost)
        {
            Data.Stamina -= staminaCost;
            SendPacket(new PacketStaminaInfoScNotify(this));
        }

        public void OnAddExp()
        {
            GameData.PlayerLevelConfigData.TryGetValue(Data.Level, out var config);
            GameData.PlayerLevelConfigData.TryGetValue(Data.Level + 1, out var config2);
            if (config == null || config2 == null) return;
            var nextExp = config2.PlayerExp - config.PlayerExp;

            while (Data.Exp >= nextExp)
            {
                Data.Exp -= nextExp;
                Data.Level++;
                GameData.PlayerLevelConfigData.TryGetValue(Data.Level, out config);
                GameData.PlayerLevelConfigData.TryGetValue(Data.Level + 1, out config2);
                if (config == null || config2 == null) break;
                nextExp = config2.PlayerExp - config.PlayerExp;
            }

            OnLevelChange();
            DatabaseHelper.Instance?.UpdateInstance(Data);
        }

        public void OnLevelChange()
        {
            if (!ConfigManager.Config.ServerOption.AutoUpgradeWorldLevel) return;
            int worldLevel = 0;
            foreach (var level in GameConstants.UpgradeWorldLevel)
            {
                if (level <= Data.Level)
                {
                    worldLevel++;
                }
            }

            if (Data.WorldLevel != worldLevel)
            {
                Data.WorldLevel = worldLevel;
            }
        }

        #endregion

        #region Scene Actions

        public void OnMove()
        {
            if (SceneInstance != null)
            {
                EntityProp? prop = SceneInstance.GetNearestSpring(25_000_000);

                bool isInRange = prop != null;

                if (isInRange)
                {
                    if (LineupManager?.GetCurLineup()?.Heal(10000, true) == true)
                    {
                        SendPacket(new PacketSyncLineupNotify(LineupManager.GetCurLineup()!));
                    }
                }
            }
        }

        public EntityProp? InteractProp(int propEntityId, int interactId)
        {
            if (SceneInstance != null)
            {
                SceneInstance.Entities.TryGetValue(propEntityId, out IGameEntity? entity);
                if (entity == null) return null;
                if (entity is EntityProp prop)
                {
                    GameData.InteractConfigData.TryGetValue(interactId, out var config);
                    if (config == null || config.SrcState != prop.State) return prop;
                    var oldState = prop.State;
                    prop.SetState(config.TargetState);
                    var newState = prop.State;
                    SendPacket(new PacketGroupStateChangeScNotify(Data.EntryId, prop.GroupID, prop.State));

                    switch (prop.Excel.PropType)
                    {
                        case PropTypeEnum.PROP_TREASURE_CHEST:
                            if (oldState == PropStateEnum.ChestClosed && newState == PropStateEnum.ChestUsed)
                            {
                                // TODO: Add treasure chest handling
                            }
                            break;
                        case PropTypeEnum.PROP_DESTRUCT:
                            if (newState == PropStateEnum.Closed)
                            {
                                prop.SetState(PropStateEnum.Open);
                            }
                            break;
                        case PropTypeEnum.PROP_MAZE_PUZZLE:
                            if (newState == PropStateEnum.Closed || newState == PropStateEnum.Open)
                            {
                                foreach (var p in SceneInstance.GetEntitiesInGroup<EntityProp>(prop.GroupID))
                                {
                                    if (p.Excel.PropType == PropTypeEnum.PROP_TREASURE_CHEST)
                                    {
                                        p.SetState(PropStateEnum.ChestUsed);
                                    }
                                    else if (p.Excel.PropType == PropTypeEnum.PROP_MAZE_PUZZLE)
                                    {
                                        // Skip
                                    }
                                    else
                                    {
                                        p.SetState(PropStateEnum.Open);
                                    }
                                    MissionManager!.OnPlayerInteractWithProp();
                                }
                            }
                            break;
                    }

                    // for door unlock
                    if (prop.PropInfo.UnlockDoorID.Count > 0)
                    {
                        foreach (var id in prop.PropInfo.UnlockDoorID)
                        {
                            foreach (var p in SceneInstance.GetEntitiesInGroup<EntityProp>(prop.GroupID))
                            {
                                if (id == p.PropInfo.ID)
                                {
                                    p.SetState(PropStateEnum.Open);
                                    MissionManager!.OnPlayerInteractWithProp();
                                }
                            }
                        }
                    }

                    // for mission
                    MissionManager!.OnPlayerInteractWithProp();

                    // plane event
                    InventoryManager!.HandlePlaneEvent(prop.PropInfo.EventID);

                    return prop;
                }
            }
            return null;
        }

        public void EnterScene(int entryId, int teleportId, bool sendPacket)
        {
            GameData.MapEntranceData.TryGetValue(entryId, out var entrance);
            if (entrance == null) return;

            GameData.GetFloorInfo(entrance.PlaneID, entrance.FloorID, out var floorInfo);
            if (floorInfo == null) return;

            int StartGroup = entrance.StartGroupID;
            int StartAnchor = entrance.StartAnchorID;

            if (teleportId != 0)
            {
                floorInfo.CachedTeleports.TryGetValue(teleportId, out var teleport);
                if (teleport != null)
                {
                    StartGroup = teleport.AnchorGroupID;
                    StartAnchor = teleport.AnchorID;
                }
            } else if (StartAnchor == 0)
            {
                StartGroup = floorInfo.StartGroupID;
                StartAnchor = floorInfo.StartAnchorID;
            }
            AnchorInfo? anchor = floorInfo.GetAnchorInfo(StartGroup, StartAnchor);

            LoadScene(entrance.PlaneID, entrance.FloorID, entryId, anchor!.ToPositionProto(), anchor.ToRotationProto(), sendPacket);
            
            MissionManager?.HandleFinishType(MissionFinishTypeEnum.EnterMapByEntrance, entryId);
        }

        public void EnterMissionScene(int entranceId, int anchorGroupId, int anchorId, bool sendPacket)
        {
            GameData.MapEntranceData.TryGetValue(entranceId, out var entrance);
            if (entrance == null) return;

            GameData.GetFloorInfo(entrance.PlaneID, entrance.FloorID, out var floorInfo);
            if (floorInfo == null) return;

            int StartGroup = anchorGroupId == 0 ? entrance.StartGroupID : anchorGroupId;
            int StartAnchor = anchorId == 0 ? entrance.StartAnchorID : anchorId;

            if (StartAnchor == 0)
            {
                StartGroup = floorInfo.StartGroupID;
                StartAnchor = floorInfo.StartAnchorID;
            }
            AnchorInfo? anchor = floorInfo.GetAnchorInfo(StartGroup, StartAnchor);

            LoadScene(entrance.PlaneID, entrance.FloorID, entranceId, anchor!.ToPositionProto(), anchor.ToRotationProto(), sendPacket);
        }

        public void MoveTo(Position position)
        {
            Data.Pos = position;
            SendPacket(new PacketSceneEntityMoveScNotify(this));
        }

        public void MoveTo(EntityMotion motion)
        {
            Data.Pos = motion.Motion.Pos.ToPosition();
            Data.Rot = motion.Motion.Rot.ToPosition();
        }


        public void LoadScene(int planeId, int floorId, int entryId, Position pos, Position rot, bool sendPacket)
        {
            GameData.MazePlaneData.TryGetValue(planeId, out var plane);
            if (plane == null) return;

            if (plane.PlaneType == PlaneTypeEnum.Rogue && RogueManager!.RogueInstance == null)
            {
                EnterScene(801120102, 0, sendPacket);
                return;
            }

            // TODO: Sanify check
            Data.Pos = pos;
            Data.Rot = rot;
            SceneInstance instance = new(this, plane, floorId, entryId);
            if (planeId != Data.PlaneId || floorId != Data.FloorId || entryId != Data.EntryId)
            {
                Data.PlaneId = planeId;
                Data.FloorId = floorId;
                Data.EntryId = entryId;
                DatabaseHelper.Instance?.UpdateInstance(Data);
            }
            SceneInstance = instance;

            if (sendPacket)
            {
                SendPacket(new PacketEnterSceneByServerScNotify(instance));
            }
        }

        public ScenePropData? GetScenePropData(int floorId, int groupId, int propId)
        {
            if (SceneData != null)
            {
                if (SceneData.ScenePropData.TryGetValue(floorId, out var floorData))
                {
                    if (floorData.TryGetValue(groupId, out var groupData))
                    {
                        var propData = groupData.Find(x => x.PropId == propId);
                        return propData;
                    }
                }
            }
            return null;
        }

        public void SetScenePropData(int floorId, int groupId, int propId, PropStateEnum state)
        {
            if (SceneData != null)
            {
                if (!SceneData.ScenePropData.TryGetValue(floorId, out var floorData))
                {
                    floorData = [];
                    SceneData.ScenePropData.Add(floorId, floorData);
                }
                if (!floorData.TryGetValue(groupId, out var groupData))
                {
                    groupData = [];
                    floorData.Add(groupId, groupData);
                }
                var propData = groupData.Find(x => x.PropId == propId);  // find prop data
                if (propData == null)
                {
                    propData = new ScenePropData()
                    {
                        PropId = propId,
                        State = state,
                    };
                    groupData.Add(propData);
                }
                else
                {
                    propData.State = state;
                }
                DatabaseHelper.Instance?.UpdateInstance(SceneData);
            }
        }

        public void EnterSection(int sectionId)
        {
            if (SceneInstance != null)
            {
                SceneData!.UnlockSectionIdList.TryGetValue(SceneInstance.FloorId, out var unlockList);
                if (unlockList == null)
                {
                    unlockList = [sectionId];
                    SceneData.UnlockSectionIdList.Add(SceneInstance.FloorId, unlockList);
                } else
                {
                    SceneData.UnlockSectionIdList[SceneInstance.FloorId].Add(sectionId);
                }
                DatabaseHelper.Instance?.UpdateInstance(SceneData);
            }
        }

        public void SetCustomSaveData(int entryId, int groupId, string data)
        {
            if (SceneData != null)
            {
                if (!SceneData.CustomSaveData.TryGetValue(entryId, out var entryData))
                {
                    entryData = [];
                    SceneData.CustomSaveData.Add(entryId, entryData);
                }
                entryData[groupId] = data;
                DatabaseHelper.Instance?.UpdateInstance(SceneData);
            }
        }

        #endregion

        #region Serialization

        public PlayerBasicInfo ToProto()
        {
            return new()
            {
                Nickname = Data.Name,
                Level = (uint)Data.Level,
                Exp = (uint)Data.Exp,
                WorldLevel = (uint)Data.WorldLevel,
                Scoin = (uint)Data.Scoin,
                Hcoin = (uint)Data.Hcoin,
                Mcoin = (uint)Data.Mcoin,
                Stamina = (uint)Data.Stamina,
            };
        }

        public PlayerSimpleInfo ToSimpleProto()
        {
            return new()
            {
                Nickname = Data.Name,
                Level = (uint)Data.Level,
                Signature = Data.Signature,
            };
        }

        #endregion
    }
}
