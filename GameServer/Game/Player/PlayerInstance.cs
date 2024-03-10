using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Game.Avatar;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Game.Inventory;
using EggLink.DanhengServer.Game.Lineup;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Game.Scene.Entity;
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
        public PlayerData Data { get; set; } = data;
        public ushort Uid { get; set; }
        public Connection? Connection { get; set; }
        public bool Initialized { get; set; } = false;
        public bool IsNewPlayer { get; set; } = false;
        public int NextBattleId { get; set; } = 0;

        #region Managers

        public AvatarManager AvatarManager { get; private set; }
        public LineupManager LineupManager { get; private set; }
        public InventoryManager InventoryManager { get; private set; }
        public BattleManager? BattleManager { get; private set; }
        public BattleInstance? BattleInstance { get; set; }

        #endregion

        #region Datas

        public PlayerUnlockData PlayerUnlockData { get; private set; }
        public SceneInstance SceneInstance { get; private set; }

        #endregion

        public PlayerInstance(int uid) : this(new PlayerData() { Uid = uid })
        {
            // new player
            IsNewPlayer = true;
            Data.Name = "无名客"; // Trailblazer in EN  TODO: Add localization
            Data.Signature = ""; 
            Data.Birthday = 0;
            Data.CurBasicType = 8001;
            Data.HeadIcon = 208001;
            Data.PhoneTheme = 221000;
            Data.ChatBubble = 220000;
            Data.CurrentBgm = 210000;
            Data.CurrentGender = Gender.Man;
            Data.Stamina = 240;
            Data.StaminaReserve = 0;
            Data.NextStaminaRecover = DateTime.Now.Millisecond;
            Data.Level = 1;
            Data.Exp = 0;
            Data.WorldLevel = 0;
            Data.Scoin = 0;
            Data.Hcoin = 0;
            Data.Mcoin = 0;
            Data.PlaneId = 20001;
            Data.FloorId = 20001001;
            Data.TalentPoints = 0;
            DatabaseHelper.Instance?.SaveInstance(Data);

            InitialPlayerManager();

            AddAvatar(1005);
            LineupManager.SetCurLineup(1);
            LineupManager.AddAvatarToCurTeam(1005);

            EnterScene(2000101, 0, false);

            Initialized = true;
        }

        private void InitialPlayerManager()
        {
            Uid = (ushort)Data.Uid;
            AvatarManager = new(this);
            LineupManager = new(this);
            InventoryManager = new(this);
            BattleManager = new(this);

            var unlock = DatabaseHelper.Instance?.GetInstance<PlayerUnlockData>(Uid);
            if (unlock == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new PlayerUnlockData()
                {
                    Uid = Uid,
                });
                unlock = DatabaseHelper.Instance?.GetInstance<PlayerUnlockData>(Uid);
            }
            PlayerUnlockData = unlock!;

            if (!IsNewPlayer)
            {
                LoadScene(Data.PlaneId, Data.FloorId, Data.EntryId, Data.Pos!, Data.Rot!, false);
            }
        }



        #region Network
        public void OnLogin()
        {
            if (!Initialized)
            {
                InitialPlayerManager();
            }
            
            SendPacket(new PacketStaminaInfoScNotify(this));

        }

        public async Task OnLogoutAsync()
        {
            DatabaseHelper.Instance?.UpdateInstance(Data);
            DatabaseHelper.Instance?.UpdateInstance(PlayerUnlockData);
            DatabaseHelper.Instance?.UpdateInstance(LineupManager.LineupData);
            DatabaseHelper.Instance?.UpdateInstance(InventoryManager.Data);
            DatabaseHelper.Instance?.UpdateInstance(AvatarManager.AvatarData!);
        }

        public void SendPacket(BasePacket packet)
        {
            Connection?.SendPacket(packet);
        }
        #endregion

        #region Extra

        public void AddAvatar(int avatarId)
        {
            AvatarManager.AddAvatar(avatarId);
        }

        public void OnMove()
        {
            if (SceneInstance != null)
            {
                EntityProp? prop = SceneInstance.GetNearestSpring(25_000_000);

                bool isInRange = prop != null;

                if (isInRange)
                {
                    if (LineupManager.GetCurLineup()?.Heal(10000, true) == true)
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
                    var newState = prop.State = config.TargetState;
                    SendPacket(new PacketGroupStateChangeScNotify(Data.EntryId, prop.GroupID, prop.State));
                    switch (prop.Excel.PropType)
                    {
                        case Enums.PropTypeEnum.PROP_TREASURE_CHEST:
                            if (oldState == Enums.PropStateEnum.ChestClosed && newState == Enums.PropStateEnum.ChestUsed)
                            {
                                // TODO: Add treasure chest handling
                            }
                            break;
                        case Enums.PropTypeEnum.PROP_DESTRUCT:
                            if (newState == Enums.PropStateEnum.Closed)
                            {
                                prop.State = Enums.PropStateEnum.Open;
                            }
                            break;
                        case Enums.PropTypeEnum.PROP_MAZE_PUZZLE:
                            if (newState == Enums.PropStateEnum.Closed || newState == Enums.PropStateEnum.Open)
                            {
                                foreach (var p in SceneInstance.GetEntitiesInGroup<EntityProp>(prop.GroupID))
                                {
                                    if (p.Excel.PropType == Enums.PropTypeEnum.PROP_TREASURE_CHEST)
                                    {
                                        p.State = Enums.PropStateEnum.ChestClosed;
                                    }
                                    else if (p.Excel.PropType == Enums.PropTypeEnum.PROP_MAZE_PUZZLE)
                                    {
                                        // Skip
                                    }
                                    else
                                    {
                                        p.State = Enums.PropStateEnum.Open;
                                    }
                                }
                            }
                            break;
                    }
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
        }

        public void MoveTo(Position position)
        {
            Data.Pos = position;
            SendPacket(new PacketSceneEntityMoveScNotify(this));
        }


        public void LoadScene(int planeId, int floorId, int entryId, Position pos, Position rot, bool sendPacket)
        {
            GameData.MazePlaneData.TryGetValue(planeId, out var plane);
            if (plane == null) return;

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

        public void SpendStamina(int staminaCost)
        {
            Data.Stamina -= staminaCost;
            SendPacket(new PacketStaminaInfoScNotify(this));
        }

        #endregion

        #region Proto

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

        #endregion
    }
}
