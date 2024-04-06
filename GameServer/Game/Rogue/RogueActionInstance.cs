using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Rogue
{
    public class RogueActionInstance
    {
        public int QueuePosition { get; set; } = 0;
        public RogueCommonBuffSelectInfo? RogueCommonBuffSelectInfo { get; set; }
        public RogueMiracleSelectInfo? RogueMiracleSelectInfo { get; set; }
        public RogueBonusSelectInfo? RogueBonusSelectInfo { get; set; }

        public RogueCommonPendingAction ToProto()
        {
            var action = new RogueAction();

            if (RogueCommonBuffSelectInfo != null)
            {
                action.BuffSelectInfo = RogueCommonBuffSelectInfo;
            }

            if (RogueMiracleSelectInfo != null)
            {
                action.MiracleSelectInfo = RogueMiracleSelectInfo;
            }

            if (RogueBonusSelectInfo != null)
            {
                action.BonusSelectInfo = RogueBonusSelectInfo;
            }

            return new()
            {
                QueuePosition = (uint)QueuePosition,
                RogueAction = action
            };
        }
    }
}
