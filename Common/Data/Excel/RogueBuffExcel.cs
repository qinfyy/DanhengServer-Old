using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("RogueBuff.json")]
    public class RogueBuffExcel : ExcelResource
    {
        public int MazeBuffID { get; set; }
        public int MazeBuffLevel { get; set; }
        public int RogueBuffType { get; set; }
        public int RogueBuffRarity { get; set; }
        public int RogueBuffTag { get; set; }

        public override int GetId()
        {
            return MazeBuffID * 100 + MazeBuffLevel;
        }

        public override void Loaded()
        {
            GameData.RogueBuffData.Add(GetId(), this);
        }
    }
}
