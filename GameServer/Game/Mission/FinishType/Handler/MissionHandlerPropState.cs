using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene.Entity;

namespace EggLink.DanhengServer.Game.Mission.FinishType.Handler
{
    [MissionFinishType(MissionFinishTypeEnum.PropState)]
    public class MissionHandlerPropState : MissionFinishTypeHandler
    {
        public override void HandleFinishType(PlayerInstance player, int Param1, int Param2, int Param3, int subMissionId)
        {
            var prop = player.SceneInstance!.GetEntitiesInGroup<EntityProp>(Param1);
            if (prop == null) return;

            foreach (var p in prop)
            {
                if (p.PropInfo.ID == Param2 && p.State != PropStateEnum.Open)
                {
                    p.SetState(PropStateEnum.Closed);
                }
            }
        }
    }
}
