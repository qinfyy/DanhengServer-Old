using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public class EntityMonster(SceneInstance scene, Position pos, Position rot, int GroupID, int InstID, NPCMonsterDataExcel excel, MonsterInfo info) : IGameEntity
    {
        public int EntityID { get; set; } = 0;
        public int GroupID { get; set; } = GroupID;
        public Position Position { get; set; } = pos;
        public Position Rotation { get; set; } = rot;
        public int InstID { get; set; } = InstID;
        public NPCMonsterDataExcel MonsterData { get; set; } = excel;
        public MonsterInfo Info { get; set; } = info;

        public int GetStageId()
        {
            return Info.EventID * 10 + scene.Player.Data.WorldLevel;
        }

        public SceneEntityInfo ToProto()
        {
            return new()
            {
                EntityId = (uint)EntityID,
                GroupId = (uint)GroupID,
                InstId = (uint)InstID,
                Motion = new()
                {
                    Pos = Position.ToProto(),
                    Rot = Rotation.ToProto()
                },
                NpcMonster = new()
                {
                    EventId = (uint)Info.EventID,
                    MonsterId = (uint)MonsterData.ID,
                    WorldLevel = (uint)scene.Player.Data.WorldLevel,
                }

            };
        }
    }
}
