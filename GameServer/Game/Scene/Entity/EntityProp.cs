using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public class EntityProp(SceneInstance scene, MazePropExcel excel, GroupInfo group, PropInfo prop) : IGameEntity
    {
        public int EntityID { get; set; }
        public int GroupID { get; set; } = group.Id;
        public Position Position { get; set; } = prop.ToPositionProto();
        public Position Rotation { get; set; } = prop.ToRotationProto();
        public PropStateEnum State { get; set; } = PropStateEnum.Closed;
        public int InstId { get; set; } = prop.ID;
        public MazePropExcel Excel { get; set; } = excel;
        public PropInfo PropInfo { get; set; } = prop;

        public PropRogueInfo? RogueInfo { get; set; }

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
