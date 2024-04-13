using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Rogue.Buff;
using EggLink.DanhengServer.Game.Rogue.Scene;
using EggLink.DanhengServer.Game.Rogue.Miracle;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using EggLink.DanhengServer.Server.Packet.Send.Rogue;
using EggLink.DanhengServer.Server.Packet.Send.Scene;

namespace EggLink.DanhengServer.Game.Rogue
{
    public class RogueInstance
    {
        #region Properties

        public PlayerInstance Player { get; set; }
        public int RogueVersionId { get; set; } = 101;
        public RogueStatus Status { get; set; } = RogueStatus.Doing;
        public Database.Lineup.LineupInfo CurLineup { get; set; } = new();
        public int CurReviveCost { get; set; } = 80;
        public int CurRerollCost { get; set; } = 30;
        public int BaseRerollCount { get; set; } = 0;
        public int BaseRerollFreeCount { get; set; } = 0;
        public int CurReachedRoom { get; set; } = 0;
        public int CurMoney { get; set; } = 100;
        public int AeonId { get; set; } = 0;
        public bool IsWin { get; set; } = false;
        public List<RogueBuffInstance> RogueBuffs { get; set; } = [];
        public Dictionary<int, RogueMiracleInstance> RogueMiracles { get; set; } = [];

        public RogueAeonExcel AeonExcel { get; set; }
        public RogueAreaConfigExcel AreaExcel { get; set; }
        public Dictionary<int, RogueRoomInstance> RogueRooms { get; set; } = [];
        public RogueRoomInstance? CurRoom { get; set; }
        public int StartSiteId { get; set; } = 0;

        public SortedDictionary<int, RogueActionInstance> RogueActions { get; set; } = [];  // queue_position -> action
        public int CurActionQueuePosition { get; set; } = 0;
        public int CurEventUniqueID { get; set; } = 100;

        #endregion

        #region Initialization

        public RogueInstance(RogueAreaConfigExcel areaExcel, RogueAeonExcel aeonExcel, PlayerInstance player)
        {
            AreaExcel = areaExcel;
            AeonExcel = aeonExcel;
            AeonId = aeonExcel.AeonID;
            Player = player;
            CurLineup = player.LineupManager!.GetCurLineup()!;

            foreach (var item in areaExcel.RogueMaps.Values)
            {
                RogueRooms.Add(item.SiteID, new(item));
                if (item.IsStart)
                {
                    StartSiteId = item.SiteID;
                }
            }

            // add bonus
            var action = new RogueActionInstance()
            {
                QueuePosition = CurActionQueuePosition,
            };
            action.SetBonus();

            RogueActions.Add(CurActionQueuePosition, action);
        }

        #endregion

        #region Methods

        public void RollBuff(int amount)
        {
            if (CurRoom!.Excel.RogueRoomType == 6)
            {
                RollBuff(amount, 100003, 2);
            }
            else
            {
                RollBuff(amount, 100005);
            }
        }

        public void RollBuff(int amount, int buffGroupId, int buffHintType = 1)
        {
            var buffGroup = GameData.RogueBuffGroupData[buffGroupId];
            var buffList = buffGroup.BuffList;

            for (int i = 0; i < amount; i++)
            {
                var menu = new RogueBuffSelectMenu(this);
                menu.RollBuff(buffList);
                menu.HintId = buffHintType;
                var action = menu.GetActionInstance();
                RogueActions.Add(action.QueuePosition, action);
            }

            UpdateMenu();
        }

        public void UpdateMenu()
        {
            if (RogueActions.Count > 0)
            {
                Player.SendPacket(new PacketSyncRogueCommonPendingActionScNotify(RogueActions.First().Value, RogueVersionId));
            }
        }

        public RogueRoomInstance? EnterRoom(int siteId)
        {
            var prevRoom = CurRoom;
            if (prevRoom != null)
            {
                if (!prevRoom.NextSiteIds.Contains(siteId))
                {
                    return null;
                }
                prevRoom.Status = RogueRoomStatus.Finish;
                // send
                Player.SendPacket(new PacketSyncRogueMapRoomScNotify(prevRoom, AreaExcel.MapId));
            }

            // next room
            CurReachedRoom++;
            CurRoom = RogueRooms[siteId];
            CurRoom.Status = RogueRoomStatus.Play;

            Player.EnterScene(CurRoom.Excel.MapEntrance, 0, false);

            // move
            AnchorInfo? anchor = Player.SceneInstance!.FloorInfo?.GetAnchorInfo(CurRoom.Excel.GroupID, 1);
            if (anchor != null)
            {
                Player.Data.Pos = anchor.ToPositionProto();
                Player.Data.Rot = anchor.ToRotationProto();
            }

            // send
            Player.SendPacket(new PacketSyncRogueMapRoomScNotify(CurRoom, AreaExcel.MapId));

            return CurRoom;
        }

        public void LeaveRogue()
        {
            Status = RogueStatus.Finish;
            Player.RogueManager!.RogueInstance = null;
            Player.EnterScene(801120102, 0, false);
            Player.LineupManager!.SetExtraLineup(ExtraLineupType.LineupNone, []);
            
            // TODO: calculate score
        }

        public void CostMoney(int amount)
        {
            CurMoney -= amount;
            Player.SendPacket(new PacketSyncRogueVirtualItemScNotify(this));
        }

        public void GainMoney(int amount)
        {
            CurMoney += amount;
            Player.SendPacket(new PacketSyncRogueVirtualItemScNotify(this));
            Player.SendPacket(new PacketScenePlaneEventScNotify(new Database.Inventory.ItemData()
            {
                ItemId = 31,
                Count = amount,
            }));
        }

        public void HandleBuffSelect(int buffId)
        {
            if (RogueActions.Count == 0)
            {
                return;
            }

            var action = RogueActions.First().Value;
            if (action.RogueBuffSelectMenu != null)
            {
                var buff = action.RogueBuffSelectMenu.Buffs.Find(x => x.MazeBuffID == buffId);
                if (buff != null)  // check if buff is in the list
                {
                    var instance = new RogueBuffInstance(buff.MazeBuffID, buff.MazeBuffLevel);
                    RogueBuffs.Add(instance);
                    Player.SendPacket(new PacketSyncRogueCommonActionResultScNotify(RogueVersionId, instance.ToResultProto(RogueActionSource.RogueCommonActionResultSourceTypeSelect)));
                }
                RogueActions.Remove(action.QueuePosition);
            }

            UpdateMenu();

            Player.SendPacket(new PacketHandleRogueCommonPendingActionScRsp(action.QueuePosition, selectBuff: true));
        }

        public void HandleBonusSelect(int bonusId)
        {
            if (RogueActions.Count == 0)
            {
                return;
            }

            var action = RogueActions.First().Value;

            // TODO: handle bonus

            RogueActions.Remove(action.QueuePosition);
            UpdateMenu();

            Player.SendPacket(new PacketHandleRogueCommonPendingActionScRsp(action.QueuePosition, selectBonus: true));
        }

        public void HandleRerollBuff()
        {
            if (RogueActions.Count == 0)
            {
                return;
            }
            var action = RogueActions.First().Value;
            if (action.RogueBuffSelectMenu != null)
            {
                action.RogueBuffSelectMenu.RerollBuff();  // reroll
                Player.SendPacket(new PacketHandleRogueCommonPendingActionScRsp(RogueVersionId, menu:action.RogueBuffSelectMenu));
            }
        }

        #endregion

        #region Handlers

        public void OnBattleStart(BattleInstance battle)
        {
            foreach (var miracle in RogueMiracles.Values)
            {
                miracle.OnStartBattle(battle);
            }

            foreach (var buff in RogueBuffs)
            {
                buff.OnStartBattle(battle);
            }

            GameData.RogueMapData.TryGetValue(AreaExcel.MapId, out var mapData);
            if (mapData != null)
            {
                mapData.TryGetValue(CurRoom!.SiteId, out var mapInfo);
                if (mapInfo != null && mapInfo.LevelList.Count > 0)
                {
                    battle.CustomLevel = mapInfo.LevelList[0];
                }
            }
        }

        public void OnBattleEnd(BattleInstance battle, PVEBattleResultCsReq req)
        {
            foreach (var miracle in RogueMiracles.Values)
            {
                miracle.OnEndBattle(battle);
            }

            RollBuff(battle.Stages.Count);
            GainMoney(Random.Shared.Next(20, 60) * battle.Stages.Count);
        }

        #endregion

        #region Serialization

        public RogueCurrentInfo ToProto()
        {
            var proto = new RogueCurrentInfo()
            {
                Status = Status,
                GameMiracleInfo = ToMiracleInfo(),
                RogueAeonInfo = ToAeonInfo(),
                RogueLineupInfo = ToLineupInfo(),
                RogueBuffInfo = ToBuffInfo(),
                RogueVirtualItem = ToVirtualItemInfo(),
                MapInfo = ToMapInfo(),
                ModuleInfo = new()
                {
                    ModuleIdList = { 1, 2, 3, 4, 5 },
                },
                IsWin = IsWin,
            };

            if (RogueActions.Count > 0)
            {
                proto.PendingAction = RogueActions.First().Value.ToProto();
            }

            return proto;
        }

        public GameMiracleInfo ToMiracleInfo()
        {
            var proto = new GameMiracleInfo()
            {
                GameMiracleInfo_ = new()
                {
                    MiracleList = { },  // for the client serialization
                }
            };
            foreach (var miracle in RogueMiracles.Values)
            {
                proto.GameMiracleInfo_.MiracleList.Add(miracle.ToProto());
            }
            return proto;
        }

        public GameAeonInfo ToAeonInfo()
        {
            return new()
            {
                AeonId = (uint)AeonId,
                IsUnlocked = AeonId != 0,
                UnlockedAeonEnhanceNum = (uint)(AeonId != 0 ? 3 : 0)
            };
        }

        public RogueLineupInfo ToLineupInfo()
        {
            var proto = new RogueLineupInfo();

            foreach (var avatar in CurLineup.BaseAvatars!)
            {
                proto.BaseAvatarIdList.Add((uint)avatar.BaseAvatarId);
            }

            proto.ReviveInfo = new()
            {
                // need to implement
            };

            return proto;
        }

        public RogueBuffInfo ToBuffInfo()
        {
            var proto = new RogueBuffInfo();

            foreach (var buff in RogueBuffs)
            {
                proto.MazeBuffList.Add(buff.ToProto());
            }

            return proto;
        }

        public RogueVirtualItem ToVirtualItemInfo()
        {
            return new()
            {
                RogueMoney = (uint)CurMoney,
            };
        }

        public RogueMapInfo ToMapInfo()
        {
            var proto = new RogueMapInfo()
            {
                CurSiteId = (uint)CurRoom!.SiteId,
                CurRoomId = (uint)CurRoom!.RoomId,
                AreaId = (uint)AreaExcel.RogueAreaID,
                MapId = (uint)AreaExcel.MapId,
            };

            foreach (var room in RogueRooms)
            {
                proto.RoomList.Add(room.Value.ToProto());
            }

            return proto;
        }

        #endregion
    }
}
