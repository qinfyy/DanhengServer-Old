using EggLink.DanhengServer.Enums.Rogue;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("RogueMiracleEffect.json")]
    public class RogueMiracleEffectExcel : ExcelResource
    {
        public int MiracleEffectID { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RogueMiracleEffectTypeEnum MiracleEffectType { get; set; }

        public List<int> ParamList { get; set; } = [];

        public override int GetId()
        {
            return MiracleEffectID;
        }

        public override void Loaded()
        {
            GameData.RogueMiracleEffectData.Add(GetId(), this);
        }
    }
}
