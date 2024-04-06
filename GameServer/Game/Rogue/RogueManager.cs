using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Rogue
{
    public class RogueManager(PlayerInstance player) : BasePlayerManager(player)
    {
        #region Properties

        public RogueInstance? RogueInstances { get; set; }

        #endregion

        #region Information

        /// <summary>
        /// Get the begin time and end time
        /// </summary>
        /// <returns></returns>
        public static (long, long) GetCurrentRogueTime()
        {
            // get the first day of the week
            var beginTime = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek).AddHours(4);
            var endTime = beginTime.AddDays(7);
            return (beginTime.ToUnixSec(), endTime.ToUnixSec());
        }

        public int GetRogueScore() => 0;  // TODO: Implement

        public static RogueManagerExcel? GetCurrentManager()
        {
            foreach (var manager in GameData.RogueManagerData.Values)
            {
                if (DateTime.Now >= manager.BeginTimeDate && DateTime.Now <= manager.EndTimeDate)
                {
                    return manager;
                }
            }
            return null;
        }

        #endregion

        #region Serialization

        public RogueInfo ToProto()
        {
            var proto = new RogueInfo()
            {
                RogueGetInfo = ToGetProto()
            };

            if (RogueInstances != null)
            {
                proto.RogueCurrentInfo = RogueInstances.ToProto();
            }

            return proto;
        }

        public RogueGetInfo ToGetProto()
        {
            return new()
            {
                RogueScoreRewardInfo = ToRewardProto(),
                RogueAeonInfo = ToAeonInfo(),
                RogueSeasonInfo = ToSeasonProto(),
                RogueAreaInfo = ToAreaProto(),
                RogueVirtualItemInfo = ToVirtualItemProto()
            };
        }

        public RogueScoreRewardInfo ToRewardProto()
        {
            var time = GetCurrentRogueTime();

            return new()
            {
                ExploreScore = (uint)GetRogueScore(),
                PoolRefreshed = true,
                PoolId = (uint)(20 + Player.Data.WorldLevel),
                BeginTime = time.Item1,
                EndTime = time.Item2,
                HasTakenInitialScore = true
            };
        }

        public static RogueAeonInfo ToAeonInfo()
        {
            var proto = new RogueAeonInfo()
            {
                IsUnlocked = true,
                UnlockedAeonNum = (uint)GameData.RogueAeonData.Count,
                UnlockedAeonEnhanceNum = 3
            };

            proto.AeonIdList.AddRange(GameData.RogueAeonData.Keys.Select(x => (uint)x));

            return proto;
        }

        public static RogueSeasonInfo ToSeasonProto()
        {
            var manager = GetCurrentManager();
            if (manager == null)
            {
                return new RogueSeasonInfo();
            }

            return new()
            {
                Season = (uint)manager.RogueSeason,
                BeginTime = manager.BeginTimeDate.ToUnixSec(),
                EndTime = manager.EndTimeDate.ToUnixSec(),
            };
        }

        public static RogueAreaInfo ToAreaProto()
        {
            var manager = GetCurrentManager();
            if (manager == null)
            {
                return new RogueAreaInfo();
            }
            return new()
            {
                RogueAreaList = {manager.RogueAreaIDList.Select(x => new RogueArea()
                {
                    AreaId = (uint)x,
                    AreaStatus = RogueAreaStatus.FirstPass,
                    HasTakenReward = true
                })}
            };
        }

        public RogueVirtualItemInfo ToVirtualItemProto()
        {
            return new()
            {
                // TODO: Implement
            };
        }

        #endregion
    }
}
