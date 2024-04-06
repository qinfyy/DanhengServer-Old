using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Rogue.Buff;
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

        public int RogueVersionId { get; set; } = 101;
        public RogueStatus Status { get; set; } = RogueStatus.Doing;
        public Dictionary<int, RogueMiracleInstance> RogueMiracles { get; set; } = [];
        public int AeonId { get; set; } = 0;
        public Database.Lineup.LineupInfo CurLineup { get; set; } = new();
        public int CurReviveCost { get; set; } = 80;
        public List<RogueBuffInstance> RogueBuffs { get; set; } = [];

        public SortedDictionary<int, RogueActionInstance> RogueActions { get; set; } = [];  // queue_position -> action

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
            return new()
            {
                // need to implement
            };
        }

        #endregion
    }
}
