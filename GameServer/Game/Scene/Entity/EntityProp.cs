using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Scene;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public class EntityProp(SceneInstance scene, MazePropExcel excel, GroupInfo group, PropInfo prop) : IGameEntity
    {
        public int EntityID { get; set; }
        public int GroupID { get; set; } = group.Id;
        public Position Position { get; set; } = prop.ToPositionProto();
        public Position Rotation { get; set; } = prop.ToRotationProto();
        public PropStateEnum State { get; private set; } = PropStateEnum.Closed;
        public int InstId { get; set; } = prop.ID;
        public MazePropExcel Excel { get; set; } = excel;
        public PropInfo PropInfo { get; set; } = prop;
        public GroupInfo Group { get; set; } = group;

        public PropRogueInfo? RogueInfo { get; set; }

        public void AddBuff(SceneBuff buff)
        {
        }

        public void ApplyBuff(BattleInstance instance)
        {
        }

        public void SetState(PropStateEnum state)
        {
            SetState(state, scene.IsLoaded);
        }

        public void SetState(PropStateEnum state, bool sendPacket)
        {
            //if (State == PropStateEnum.Open) return;  // already open   DO NOT CLOSE AGAIN
            State = state;
            if (sendPacket)
            {
                scene.Player.SendPacket(new PacketSceneGroupRefreshScNotify(this));
            }

            // save
            scene.Player.SetScenePropData(scene.FloorId, Group.Id, PropInfo.ID, state);
        }

        public SceneEntityInfo ToProto()
        {
            var prop = new ScenePropInfo()
            {
                PropId = (uint)Excel.ID,
                PropState = (uint)State,
            };

            if (RogueInfo != null)
            {
                prop.ExtraInfo.RogueInfo = RogueInfo;
            }

            return new SceneEntityInfo()
            {
                EntityId = (uint)EntityID,
                GroupId = (uint)GroupID,
                Motion = new MotionInfo()
                {
                    Pos = Position.ToProto(),
                    Rot = Rotation.ToProto(),
                },
                InstId = (uint)InstId,
                Prop = prop,
            };
        }
    }
}
