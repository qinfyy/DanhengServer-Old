using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Mission.FinishAction
{
    public abstract class MissionFinishActionHandler
    {
        public abstract void OnHandle(List<int> Params, PlayerInstance Player);
    }
}
