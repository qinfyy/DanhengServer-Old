using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene.Entity;

namespace EggLink.DanhengServer.Game.Mission.FinishType.Handler
{
    [MissionFinishType(MissionFinishTypeEnum.PropState)]
    public class MissionHandlerPropState : MissionFinishTypeHandler
    {
        public override void Init(PlayerInstance player, SubMissionInfo info, object? arg)
        {
            var prop = player.SceneInstance!.GetEntitiesInGroup<EntityProp>(info.ParamInt1);
            if (prop == null) return;

            foreach (var p in prop)
            {
                if (p.PropInfo.ID == info.ParamInt2 && p.State != PropStateEnum.Open)
                {
                    if (info.ParamInt3 != 0)
                    {
                        //player.MissionManager!.FinishSubMission(subMissionId);
                        p.SetState(PropStateEnum.Closed);
                    }
                }
            }
        }

        public override void HandleFinishType(PlayerInstance player, SubMissionInfo info, object? arg)
        {
            var prop = player.SceneInstance!.GetEntitiesInGroup<EntityProp>(info.ParamInt1);
            if (prop == null) return;

            foreach (var p in prop)
            {
                if (p.PropInfo.ID == info.ParamInt2 && (int)p.State == info.ParamInt3)
                {
                    player.MissionManager!.FinishSubMission(info.ID);
                }
            }
        }
    }
}
