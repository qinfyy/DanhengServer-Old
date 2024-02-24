using EggLink.DanhengServer.Data.Excel;
using System.Collections.Generic;

namespace EggLink.DanhengServer.Data
{
    internal static class GameData
    {
        public static Dictionary<int, AvatarConfigExcel> AvatarConfigData { get; private set; } = new Dictionary<int, AvatarConfigExcel>();
        public static Dictionary<int, StageConfigExcel> StageConfigData { get; private set; } = new Dictionary<int, StageConfigExcel>();
    }
}
