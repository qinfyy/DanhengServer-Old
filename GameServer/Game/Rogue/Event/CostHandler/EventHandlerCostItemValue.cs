using EggLink.DanhengServer.Enums.Rogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Rogue.Event.CostHandler
{
    [RogueEvent(costType: DialogueEventCostTypeEnum.CostItemValue)]
    public class EventHandlerCostItemValue : RogueEventCostHandler
    {
        public override void Handle(RogueInstance rogue, RogueEventInstance? eventInstance, List<int> ParamList)
        {
            int decreaseMoney = ParamList[1];
            rogue.CostMoney(decreaseMoney, true);
        }
    }
}
