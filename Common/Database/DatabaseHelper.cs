using EggLink.DanhengServer.Configuration;
using EggLink.DanhengServer.Util;
using Microsoft.Data.Sqlite;
using System.Reflection;

namespace EggLink.DanhengServer.Database
{
    public class DatabaseHelper
    {
        public Logger logger = new("Database");
        public ConfigContainer config = ConfigManager.Config;
        public SqliteConnection connection;
        public static DatabaseHelper Instance;

        public DatabaseHelper()
        {
            var f = new FileInfo(config.Path.DatabasePath + "/" + config.Database.DatabaseName);
            if (!f.Exists && f.Directory != null)
            {
                f.Directory.Create();
            }
            connection = new SqliteConnection($"Data Source={f.FullName};");
            Instance = this;
        }
        public void Initialize()
        {
            logger.Info("Initializing database...");
            switch (config.Database.DatabaseType)
            {
                case "sqlite":
                    InitializeSqlite();
                    break;
                default:
                    logger.Error("Unsupported database type");
                    break;
            }
        }

        public void InitializeSqlite()
        {
            SQLitePCL.Batteries.Init();
            connection.Open();
            var classes = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var cls in classes) {
                var attribute = (DatabaseEntity)Attribute.GetCustomAttribute(cls, typeof(DatabaseEntity));
                if (attribute != null)
                {
                    var tableName = attribute.TableName;
                    var createTable = $"CREATE TABLE IF NOT EXISTS {tableName} (";
                    var properties = cls.GetProperties();
                    foreach (var property in properties)
                    {
                        createTable += $"{property.Name} {GetSqliteType(property.PropertyType)}, ";
                    }
                    createTable = createTable.Substring(0, createTable.Length - 2);
                    createTable += ")";
                    var command = new SqliteCommand(createTable, connection);
                    command.ExecuteNonQuery();
                }
            }
        }

        private string GetSqliteType(Type propertyType)
        {
            if (propertyType == typeof(int))
            {
                return "INTEGER";
            }
            else if (propertyType == typeof(string))
            {
                return "TEXT";
            }
            else if (propertyType == typeof(bool))
            {
                return "INTEGER";
            }
            else if (propertyType == typeof(float))
            {
                return "REAL";
            }
            else if (propertyType == typeof(double))
            {
                return "REAL";
            }
            else if (propertyType == typeof(long))
            {
                return "INTEGER";
            }
            else if (propertyType == typeof(byte[]))
            {
                return "BLOB";
            }
            else
            {
                logger.Error($"Unsupported type {propertyType}");
                return "TEXT";
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
