using EggLink.DanhengServer.Enums;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Mission
{
    [SugarTable("mission")]
    public class MissionData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public Dictionary<int, MissionInfo> MissionInfo { get; set; } = [];
    }

    public class MissionInfo
    {
        public int MissionId { get; set; }
        public MissionPhaseEnum Status { get; set; }
    }
}
