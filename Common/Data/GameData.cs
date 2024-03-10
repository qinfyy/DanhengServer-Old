using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using System.Collections.Generic;

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

        public static void GetFloorInfo(int planeId, int floorId, out FloorInfo outter)
        {
            FloorInfoData.TryGetValue("P" + planeId + "_F" + floorId, out outter!);
        }
    }
}
