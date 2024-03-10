using EggLink.DanhengServer.Proto;
using System.Collections.Generic;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("StageConfig.json", false)]
    public class StageConfigExcel : ExcelResource
    {
        public int StageID { get; set; } = 0;
        public HashName StageName { get; set; } = new HashName();
        public List<StageMonsterList> MonsterList { get; set; } = [];


        public override int GetId()
        {
            return StageID;
        }
        public override void Loaded()
        {
            GameData.StageConfigData.Add(StageID, this);
        }

        public SceneMonsterWave ToProto()
        {
            var proto = new SceneMonsterWave()
            {
                WaveId = 1,
                StageId = (uint)StageID,
            };
            foreach (var monsters in MonsterList)
            {
                proto.MonsterList.Add(new SceneMonster()
                {
                    MonsterId = (uint)monsters.Monster0,
                });
                proto.MonsterList.Add(new SceneMonster()
                {
                    MonsterId = (uint)monsters.Monster1,
                });
                proto.MonsterList.Add(new SceneMonster()
                {
                    MonsterId = (uint)monsters.Monster2,
                });
                proto.MonsterList.Add(new SceneMonster()
                {
                    MonsterId = (uint)monsters.Monster3,
                });
                proto.MonsterList.Add(new SceneMonster()
                {
                    MonsterId = (uint)monsters.Monster4,
                });
            }
            return proto;
        }
    }

    public class StageMonsterList
    {
        public int Monster0 { get; set; } = 0;
        public int Monster1 { get; set; } = 0;
        public int Monster2 { get; set; } = 0;
        public int Monster3 { get; set; } = 0;
        public int Monster4 { get; set; } = 0;
    }

    public class HashName
    {
        public long Hash { get; set; } = 0;
    }
}
