using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("RaidConfig.json")]
    public class RaidConfigExcel : ExcelResource
    {
        public int RaidID { get; set; }
        public int HardLevel { get; set; }

        public int FinishEntranceID { get; set; }

        public List<int> MainMissionIDList { get; set; } = [];

        public override int GetId()
        {
            return RaidID * 100 + HardLevel;
        }

        public override void Loaded()
        {
            GameData.RaidConfigData.Add(GetId(), this);
        }
    }
}
