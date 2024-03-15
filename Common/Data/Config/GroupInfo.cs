using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EggLink.DanhengServer.Data.Config
{
    public class GroupInfo
    {
        public int Id;
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupLoadSideEnum LoadSide { get; set; }
        public bool LoadOnInitial { get; set; }
        public LoadCondition LoadCondition { get; set; } = new();
        public LoadCondition UnloadCondition { get; set; } = new();
        public LoadCondition ForceUnloadCondition { get; set; } = new();
        [JsonConverter(typeof(StringEnumConverter))]
        public SaveTypeEnum SaveType { get; set; } = SaveTypeEnum.Save;
        public int OwnerMainMissionID { get; set; }
        public List<AnchorInfo> AnchorList { get; set; } = [];
        public List<MonsterInfo> MonsterList { get; set; } = [];
        public List<PropInfo> PropList { get; set; } = [];
        public List<NpcInfo> NPCList { get; set; } = [];

        public void Load()
        {
            foreach (var prop in PropList)
            {
                prop.Load();
            }
        }
    }

    public class LoadCondition
    {
        public List<Condition> Conditions { get; set; } = [];

        [JsonConverter(typeof(StringEnumConverter))]
        public OperationEnum Operation { get; set; } = OperationEnum.And;
    }

    public class Condition
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ConditionTypeEnum Type { get; set; } = ConditionTypeEnum.MainMission;
        public int ID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MissionPhaseEnum Phase { get; set; } = MissionPhaseEnum.Doing;
    }
}
