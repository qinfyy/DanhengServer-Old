using EggLink.DanhengServer.Database.Mission;
using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static System.Formats.Asn1.AsnWriter;

namespace EggLink.DanhengServer.Data.Config
{
    public class GroupInfo
    {
        public int Id;
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupLoadSideEnum LoadSide { get; set; }
        public bool LoadOnInitial { get; set; }
        public string GroupName { get; set; } = "";
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

        public bool IsTrue(MissionData mission, bool defaultResult = true)
        {
            if (Conditions.Count == 0)
            {
                return defaultResult;
            }
            bool canLoad = Operation == OperationEnum.And;
            // check load condition
            foreach (var condition in Conditions)
            {
                if (condition.Type == ConditionTypeEnum.MainMission)
                {
                    if (!mission.MainMissionInfo.TryGetValue(condition.ID, out var info))
                    {
                        info = MissionPhaseEnum.None;
                    }
                    if (info != condition.Phase)
                    {
                        if (Operation == OperationEnum.And)
                        {
                            canLoad = false;
                            break;
                        }
                    }
                    else
                    {
                        if (Operation == OperationEnum.Or)
                        {
                            canLoad = true;
                            break;
                        }
                    }
                } else
                {
                    // sub mission
                    GameData.SubMissionData.TryGetValue(condition.ID, out var subMission);
                    if (subMission == null) continue;
                    var mainMissionId = subMission.MainMissionID;
                    mission.MissionInfo.TryGetValue(mainMissionId, out var info);
                    if (info?.TryGetValue(condition.ID, out var missionInfo) == true)
                    {
                        if (missionInfo.Status != condition.Phase)
                        {
                            if (Operation == OperationEnum.And)
                            {
                                canLoad = false;
                                break;
                            }
                        }
                        else
                        {
                            if (Operation == OperationEnum.Or)
                            {
                                canLoad = true;
                                break;
                            }
                        }
                    } else
                    {
                        if (condition.Phase != MissionPhaseEnum.None)
                        {
                            if (Operation == OperationEnum.And)
                            {
                                canLoad = false;
                                break;
                            }
                        }
                        else
                        {
                            if (Operation == OperationEnum.Or)
                            {
                                canLoad = true;
                                break;
                            }
                        }
                    }
                }
            }
            return canLoad;
        }
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
