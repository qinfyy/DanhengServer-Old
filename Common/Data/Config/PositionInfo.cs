using EggLink.DanhengServer.Data.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Config
{
    public class PositionInfo
    {
        public int ID { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public bool IsDelete { get; set; }
        public string Name { get; set; } = "";
        public float RotY { get; set; }
    }
}
