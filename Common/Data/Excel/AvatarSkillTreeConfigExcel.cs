using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("AvatarSkillTreeConfig.json")]
    public class AvatarSkillTreeConfigExcel : ExcelResource
    {

        public int PointID { get; set; }
        public int Level { get; set; }
        public int AvatarID { get; set; }
        public bool DefaultUnlock {  get; set; }
        public int MaxLevel { get; set; }

        public override int GetId()
        {
            return (PointID << 4) + Level;
        }

        public override void AfterAllDone()
        {
            GameData.AvatarConfigData.TryGetValue(AvatarID, out var excel);
            if (excel != null && DefaultUnlock)
            {
                excel.DefaultSkillTree.Add(this);
            }
        }
    }
}
