using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Database.Lineup
{
    [SugarTable("Lineup")]
    public class LineupData : BaseDatabaseData
    {
        public int CurLineup { get; set; }  // index of current lineup
        public string? Lineups { get; set; }  // 9 * 4
    }

    public class LineupInfo
    {
        public string? Name { get; set; }
        public int LineupType { get; set; }
        public List<int>? BaseAvatars { get; set; }
    }

    public class LineupInfoJson
    {
        public Dictionary<int, LineupInfo>? Lineups { get; set; } = [];  // 9 * 4
    }
}
