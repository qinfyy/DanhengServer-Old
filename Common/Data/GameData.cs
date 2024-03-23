using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database.Mission;

namespace EggLink.DanhengServer.Data
{
    public static class GameData
    {
        public static Dictionary<int, AvatarConfigExcel> AvatarConfigData { get; private set; } = [];
        public static Dictionary<int, CocoonConfigExcel> CocoonConfigData { get; private set; } = [];
        public static Dictionary<int, StageConfigExcel> StageConfigData { get; private set; } = [];
        public static Dictionary<int, MapEntranceExcel> MapEntranceData { get; private set; } = [];
        public static Dictionary<int, MazePlaneExcel> MazePlaneData { get; private set; } = [];
        public static Dictionary<int, MazePropExcel> MazePropData { get; private set; } = [];
        public static Dictionary<int, InteractConfigExcel> InteractConfigData { get; private set; } = [];
        public static Dictionary<int, NPCMonsterDataExcel> NpcMonsterDataData { get; private set; } = [];
        public static Dictionary<int, NPCDataExcel> NpcDataData { get; private set; } = [];
        public static Dictionary<int, QuestDataExcel> QuestDataData { get; private set; } = [];

        public static Dictionary<string, FloorInfo> FloorInfoData { get; private set; } = [];
        public static Dictionary<int, ItemConfigExcel> ItemConfigData { get; private set; } = [];
        public static Dictionary<int, Dictionary<int, RelicMainAffixConfigExcel>> RelicMainAffixData { get; private set; } = [];  // groupId, affixId
        public static Dictionary<int, Dictionary<int, RelicSubAffixConfigExcel>> RelicSubAffixData { get; private set; } = [];  // groupId, affixId
        public static Dictionary<int, RelicConfigExcel> RelicConfigData { get; private set; } = [];

        public static Dictionary<int, SpecialAvatarExcel> SpecialAvatarData { get; private set; } = [];
        public static Dictionary<int, SpecialAvatarRelicExcel> SpecialAvatarRelicData { get; private set; } = [];

        public static Dictionary<int, MainMissionExcel> MainMissionData { get; private set; } = [];
        public static Dictionary<int, SubMissionExcel> SubMissionData { get; private set; } = [];

        public static void GetFloorInfo(int planeId, int floorId, out FloorInfo outer)
        {
            FloorInfoData.TryGetValue("P" + planeId + "_F" + floorId, out outer!);
        }

        public static MapEntranceExcel? GetMapEntrance(int floorId, MissionData mission)
        {
            var data = MapEntranceData.Values.ToList().FindAll(item => item.FloorID == floorId);
            if (data.Count == 0) return null;
            MapEntranceExcel? result = null;
            foreach (var item in data)
            {
                if (item.FinishSubMissionList.Count > 0)
                {
                    foreach (var subMissionId in item.FinishSubMissionList)
                    {
                        SubMissionData.TryGetValue(subMissionId, out var subMission);
                        if (subMission == null) return null;
                        var mainMissionId = subMission.MainMissionID;
                        if (mission.MissionInfo.TryGetValue(mainMissionId, out var mainMission))
                        {
                            if (mainMission.Values.ToList().Find(i => i.Status == Enums.MissionPhaseEnum.Doing && i.MissionId == subMissionId) != null)
                            {
                                result = item;
                            }
                        }
                    }
                }
                else if (item.FinishMainMissionList.Count > 0)
                {
                    foreach (var mainMissionId in item.FinishMainMissionList)
                    {
                        if (mission.MainMissionInfo.TryGetValue(mainMissionId, out var mainMission))
                        {
                            if (mainMission == Enums.MissionPhaseEnum.Doing)
                            {
                                result = item;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
