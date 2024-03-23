using Microsoft.Data.Sqlite;
using SqlSugar;

namespace EggLink.DanhengServer.Database
{
    public abstract class BaseDatabaseData
    {
        [SugarColumn(IsPrimaryKey = true)]
        public int Uid { get; set; }
    }
}
