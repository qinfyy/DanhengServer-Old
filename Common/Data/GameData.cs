using EggLink.DanhengServer.Data.Excel;
using System.Collections.Generic;

namespace EggLink.DanhengServer.Data
{
    public static class GameData
    {
        public static Dictionary<int, AvatarConfigExcel> AvatarConfigData { get; private set; } = [];
        public static Dictionary<int, StageConfigExcel> StageConfigData { get; private set; } = [];
        public static Dictionary<int, MapEntranceExcel> MapEntranceData { get; private set; } = [];
    }
}
