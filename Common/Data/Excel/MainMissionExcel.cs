using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("MainMission.json")]
    public class MainMissionExcel : ExcelResource
    {
        public int MainMissionID { get; set; }
        public HashName Name { get; set; } = new();
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationEnum TakeOperation { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationEnum BeginOperation { get; set; }

        public List<MissionParam> TakeParam { get; set; } = [];
        public List<MissionParam> BeginParam { get; set; } = [];
        public int RewardID { get; set; }

        [JsonIgnore()]
        public MissionInfo? MissionInfo { get; set; }


        public override int GetId()
        {
            return MainMissionID;
        }

        public override void Loaded()
        {
            GameData.MainMissionData[GetId()] = this;
        }
    }

    public class MissionParam
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MissionTakeTypeEnum Type { get; set; }
        public int Value { get; set; }
    }
}
