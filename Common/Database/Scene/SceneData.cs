using EggLink.DanhengServer.Enums;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Scene
{
    [SugarTable("Scene")]
    public class SceneData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public Dictionary<int, Dictionary<int, List<ScenePropData>>> ScenePropData { get; set; } = [];  // Dictionary<FloorId, Dictionary<GroupId, ScenePropData>>
        
        [SugarColumn(IsJson = true)]
        public Dictionary<int, List<int>> UnlockSectionIdList { get; set; } = [];  // Dictionary<FloorId, List<SectionId>>

        [SugarColumn(IsJson = true)]
        public Dictionary<int, Dictionary<int, string>> CustomSaveData { get; set; } = [];  // Dictionary<EntryId, Dictionary<GroupId, SaveData>>
    }

    public class ScenePropData
    {
        public int PropId;
        public PropStateEnum State;
    }
}
