using EggLink.DanhengServer.Enums;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Mission
{
    [SugarTable("Mission")]
    public class MissionData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public Dictionary<int, Dictionary<int, MissionInfo>> MissionInfo { get; set; } = [];  // Dictionary<MissionId, Dictionary<SubMissionId, MissionInfo>>
        [SugarColumn(IsJson = true)]
        public Dictionary<int, MissionPhaseEnum> MainMissionInfo { get; set; } = [];  // Dictionary<MissionId, MissionPhaseEnum>
    }

    public class MissionInfo
    {
        public int MissionId { get; set; }
        public MissionPhaseEnum Status { get; set; }
    }
}
