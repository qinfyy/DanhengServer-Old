using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Mission.FinishType.Handler
{
    [MissionFinishType(MissionFinishTypeEnum.SubMissionFinishCnt)]
    public class MissionHandlerSubMissionFinishCnt : MissionFinishTypeHandler
    {
        public override void HandleFinishType(PlayerInstance player, int Param1, int Param2, int Param3, List<int> ParamIntList, int subMissionId)
        {
            foreach (var missionId in ParamIntList)
            {
                player.MissionManager!.AcceptSubMission(missionId);
                player.MissionManager!.FinishSubMission(missionId);
            }

            player.MissionManager!.FinishSubMission(subMissionId);
        }
    }
}
