using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Mission.FinishType
{
    public abstract class MissionFinishTypeHandler
    {
        public abstract void HandleFinishType(PlayerInstance player, int Param1, int Param2, int Param3, int subMissionId);
    }
}
