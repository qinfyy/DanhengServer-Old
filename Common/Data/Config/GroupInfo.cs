using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EggLink.DanhengServer.Data.Config
{
    public class GroupInfo
    {
        public int Id;
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupLoadSideEnum LoadSide { get; set; }
        public bool LoadOnInitial { get; set; }
        public int OwnerMainMissionID { get; set; }

        public List<AnchorInfo> AnchorList { get; set; } = [];
        public List<MonsterInfo> MonsterList { get; set; } = [];
        public List<PropInfo> PropList { get; set; } = [];
        public List<NpcInfo> NPCList { get; set; } = [];
    }
}
