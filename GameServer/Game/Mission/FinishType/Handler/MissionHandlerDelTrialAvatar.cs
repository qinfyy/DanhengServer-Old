using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Mission.FinishType.Handler
{
    [MissionFinishType(MissionFinishTypeEnum.DelTrialAvatar)]
    public class MissionHandlerDelTrialAvatar : MissionFinishTypeHandler
    {
        public override void HandleFinishType(PlayerInstance player, int Param1, int Param2, int Param3, List<int> ParamIntList, int subMissionId)
        {
            if (player.LineupManager!.GetCurLineup() == null) return;
            var actualSpecialAvatarId = Param1 * 10 + player.Data.WorldLevel;
            var item = player.LineupManager!.GetCurLineup()!.BaseAvatars!.Find(item => item.SpecialAvatarId == actualSpecialAvatarId);
            if (item == null) return;  // avatar not found
            player.LineupManager!.RemoveSpecialAvatarFromCurTeam(actualSpecialAvatarId);
            player.MissionManager!.FinishSubMission(subMissionId);
        }
    }
}
