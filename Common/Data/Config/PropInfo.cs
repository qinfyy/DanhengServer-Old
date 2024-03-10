using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace EggLink.DanhengServer.Data.Config
{
    public class PropInfo : PositionInfo
    {
        public float RotX { get; set; }
        public float RotZ { get; set; }
        public int MappingInfoID { get; set; }
        public int AnchorGroupID { get; set; }
        public int AnchorID { get; set; }
        public int PropID { get; set; }
        public int EventID { get; set; }
        public int CocoonID { get; set; }
        public int FarmElementID { get; set; }
        public bool IsClientOnly { get; set; }

        public PropValueSource? ValueSource { get; set; }
        public string? InitLevelGraph { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PropStateEnum State { get; set; } = PropStateEnum.Closed;
    }

    public class PropValueSource
    {
        public List<JObject> Values { get; set; } = [];
    }
}
