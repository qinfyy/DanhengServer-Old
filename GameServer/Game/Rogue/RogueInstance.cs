using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Rogue.Buff;
using EggLink.DanhengServer.Game.Rogue.Map;
using EggLink.DanhengServer.Game.Rogue.Miracle;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CurReachedRoom { get; set; } = 0;
        public int CurMoney { get; set; } = 100;
        public int AeonId { get; set; } = 0;
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
        }

        #endregion

        #region Methods

        public void RollBuff(int amount)
        {
            RollBuff(amount, 100005);
        }

        public void RollBuff(int amount, int buffGroupId, int buffHintType = 1)
        {
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

            return CurRoom;
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
                MapInfo = ToMapInfo()
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
                // need to implement
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
