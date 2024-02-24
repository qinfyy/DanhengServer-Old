using System.Collections.Generic;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("StageConfig.json", false)]
    internal class StageConfigExcel : ExcelResource
    {
        public int StageID { get; set; } = 0;
        public HashName StageName { get; set; } = new HashName();
        public List<StageMonsterList> MonsterList { get; set; } = new List<StageMonsterList>();


        public override int GetId()
        {
            return StageID;
        }
        public override void Loaded()
        {
            GameData.StageConfigData.Add(StageID, this);
        }
    }

    internal class StageMonsterList
    {
        public int Monster0 { get; set; } = 0;
        public int Monster1 { get; set; } = 0;
        public int Monster2 { get; set; } = 0;
        public int Monster3 { get; set; } = 0;
        public int Monster4 { get; set; } = 0;
    }

    internal class HashName
    {
        public long Hash { get; set; } = 0;
    }
}
