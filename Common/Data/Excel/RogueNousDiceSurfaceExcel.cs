using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("RogueNousDiceSurface.json")]
    public class RogueNousDiceSurfaceExcel : ExcelResource
    {
        public int SurfaceID { get; set; }
        public int ItemID { get; set; }
        public int Sort { get; set; }

        public override int GetId()
        {
            return SurfaceID;
        }

        public override void Loaded()
        {
            GameData.RogueNousDiceSurfaceData[SurfaceID] = this;
        }
    }
}
