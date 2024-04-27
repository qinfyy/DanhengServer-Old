using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("RogueDLCArea.json")]
    public class RogueDLCAreaExcel : ExcelResource
    {
        public int AreaID { get; set; }
        public List<int> LayerIDList { get; set; } = [];
        public int FirstReward { get; set; }

        public override int GetId()
        {
            return AreaID;
        }

        public override void Loaded()
        {
            GameData.RogueDLCAreaData[AreaID] = this;
        }
    }
}
