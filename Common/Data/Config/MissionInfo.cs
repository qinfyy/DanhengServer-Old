using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EggLink.DanhengServer.Data.Config
{
    public class MissionInfo
    {
        public int MainMissionID { get; set; }
        public List<int> StartSubMissionList { get; set; } = [];
        public List<int> FinishSubMissionList { get; set; } = [];
        public List<SubMissionInfo> SubMissionList { get; set; } = [];
    }

    public class SubMissionInfo
    {
        public int ID { get; set; }
        public int MainMissionID { get; set; }
        public List<int> TakeParamIntList { get; set; } = [];  // the mission's prerequisites
        [JsonConverter(typeof(StringEnumConverter))]
        public MissionFinishTypeEnum FinishType { get; set; }
        public int ParamInt1 { get; set; }
        public int ParamInt2 { get; set; }
        public int ParamInt3 { get; set; }
        public List<int> ParamIntList { get; set; } = [];
        public List<FinishActionInfo> FinishActionList { get; set; } = [];
        public int Progress { get; set; }
    }

    public class FinishActionInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public FinishActionTypeEnum FinishActionType { get; set; }
        public List<int> FinishActionPara { get; set; } = [];
    }
}
