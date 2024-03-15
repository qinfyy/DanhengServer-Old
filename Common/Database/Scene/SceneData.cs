using EggLink.DanhengServer.Enums;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Scene
{
    [SugarTable("scene")]
    public class SceneData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public Dictionary<int, Dictionary<int, List<ScenePropData>>> ScenePropData { get; set; } = [];  // Dictionary<FloorId, Dictionary<GroupId, ScenePropData>>
    }

    public class ScenePropData
    {
        public int PropId;
        public PropStateEnum State;
    }
}
