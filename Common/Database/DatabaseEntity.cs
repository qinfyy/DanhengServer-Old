namespace EggLink.DanhengServer.Database
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DatabaseEntity(string tableName) : Attribute
    {
        public string TableName { get; set; } = tableName;
    }
}
