using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Mission.FinishType.Handler
{
    [MissionFinishType(MissionFinishTypeEnum.GetTrialAvatar)]
    public class MissionHandlerGetTrialAvatar : MissionFinishTypeHandler
    {
        public override void HandleFinishType(PlayerInstance player, int Param1, int Param2, int Param3, List<int> ParamIntList, int subMissionId)
        {
            if (player.LineupManager!.GetCurLineup() == null) return;
            var actualSpecialAvatarId = Param1 * 10 + player.Data.WorldLevel;
            var item = player.LineupManager!.GetCurLineup()!.BaseAvatars!.Find(item => item.SpecialAvatarId == actualSpecialAvatarId);
            if (item != null) return;  // existing avatar
            player.LineupManager!.AddSpecialAvatarToCurTeam(actualSpecialAvatarId);
            // send packet
            player.MissionManager!.FinishSubMission(subMissionId);
        }
    }
}
