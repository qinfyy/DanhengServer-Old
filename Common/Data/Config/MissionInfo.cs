using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Util;
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
        public string MissionJsonPath { get; set; } = "";
        public List<int> TakeParamIntList { get; set; } = [];  // the mission's prerequisites
        [JsonConverter(typeof(StringEnumConverter))]
        public MissionFinishTypeEnum FinishType { get; set; }
        public int ParamInt1 { get; set; }
        public int ParamInt2 { get; set; }
        public int ParamInt3 { get; set; }
        public List<int> ParamIntList { get; set; } = [];
        public List<FinishActionInfo> FinishActionList { get; set; } = [];
        public int Progress { get; set; }

        [JsonIgnore]
        public SubMissionTask<EnterFloorTaskInfo> Task { get; set; } = new();
        [JsonIgnore]
        public SubMissionTask<PropStateTaskInfo> PropTask { get; set; } = new();

        [JsonIgnore]
        public int MapEntranceID { get; set; }

        [JsonIgnore]
        public int AnchorGroupID { get; set; }
        [JsonIgnore]
        public int AnchorID { get; set; }

        [JsonIgnore]
        public PropStateEnum SourceState { get; set; } = PropStateEnum.Closed;

        public void Loaded(int type)  // 1 for EnterFloor, 2 for PropState
        {
            if (type == 1)
            {
                try
                {
                    if (Task.OnStartSequece.Count > 0)
                    {
                        MapEntranceID = Task.OnStartSequece[0].TaskList[0].EntranceID;
                        AnchorGroupID = Task.OnStartSequece[0].TaskList[0].GroupID;
                        AnchorID = Task.OnStartSequece[0].TaskList[0].AnchorID;
                    }
                    else if (Task.OnInitSequece.Count > 0)
                    {
                        MapEntranceID = Task.OnInitSequece[0].TaskList[0].EntranceID;
                        AnchorGroupID = Task.OnInitSequece[0].TaskList[0].GroupID;
                        AnchorID = Task.OnInitSequece[0].TaskList[0].AnchorID;
                    }
                    if (MapEntranceID == 0)
                    {
                        MapEntranceID = int.Parse(ParamInt2.ToString().Replace("00", "0"));  // this is a hacky way to get the MapEntranceID
                    }
                }
                catch
                {
                    MapEntranceID = int.Parse(ParamInt2.ToString().Replace("00", "0"));  // this is a hacky way to get the MapEntranceID
                }
            } else if (type == 2)
            {
                foreach (var task in PropTask.OnStartSequece)
                {
                    foreach (var prop in task.TaskList)
                    {
                        if (prop.ButtonCallBack != null)
                        {
                            SourceState = prop.ButtonCallBack[0].State;
                        }
                    }
                }

                foreach (var task in PropTask.OnInitSequece)
                {
                    foreach (var prop in task.TaskList)
                    {
                        if (prop.ButtonCallBack != null)
                        {
                            SourceState = prop.ButtonCallBack[0].State;
                        }
                    }
                }
            }
        }
    }

    public class FinishActionInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public FinishActionTypeEnum FinishActionType { get; set; }
        public List<int> FinishActionPara { get; set; } = [];
    }

    public class SubMissionTask<T>
    {
        public List<SubMissionTaskInfo<T>> OnInitSequece { get; set; } = [];
        public List<SubMissionTaskInfo<T>> OnStartSequece { get; set; } = [];
    }

    public class SubMissionTaskInfo<T>
    {
        public List<T> TaskList { get; set; } = [];
    }

    public class EnterFloorTaskInfo
    {
        public int EntranceID { get; set; }
        public int GroupID { get; set; }
        public int AnchorID { get; set; }
    }

    public class PropStateTaskInfo
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public PropStateEnum State { get; set; } = PropStateEnum.Closed;

        public List<PropStateTaskInfo>? ButtonCallBack { get; set; }
    }
}
