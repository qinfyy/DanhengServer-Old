using EggLink.DanhengServer.Configuration;
using EggLink.DanhengServer.Database.Account;
using EggLink.DanhengServer.Util;
using Microsoft.Data.Sqlite;
using SqlSugar;
using System.Reflection;

namespace EggLink.DanhengServer.Database
{
    public class DatabaseHelper
    {
        public Logger logger = new("Database");
        public ConfigContainer config = ConfigManager.Config;
        public static SqlSugarScope? sqlSugarScope;
        public static DatabaseHelper? Instance;
        private static readonly object _lock = new();

        public DatabaseHelper()
        {
            var f = new FileInfo(config.Path.DatabasePath + "/" + config.Database.DatabaseName);
            if (!f.Exists && f.Directory != null)
            {
                f.Directory.Create();
            }
            sqlSugarScope = new(new ConnectionConfig()
            {
                ConnectionString = $"Data Source={f.FullName};",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
            });
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

        public static void InitializeSqlite()
        {
            var baseType = typeof(BaseDatabaseData);
            var assembly = typeof(BaseDatabaseData).Assembly;
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
            foreach (var type in types)
            {
                typeof(DatabaseHelper).GetMethod("InitializeSqliteTable")?.MakeGenericMethod(type).Invoke(null, null);
            }
        }

        public static void InitializeSqliteTable<T>() where T : class, new()
        {
            try
            {
                sqlSugarScope?.Queryable<T>().ToList();
            } catch
            {
                sqlSugarScope?.CodeFirst.InitTables<T>();
            }
        }

        public T? GetInstance<T>(long uid) where T : class, new()
        {
            try
            {
                lock (_lock)
                {
                    return sqlSugarScope?.Queryable<T>().Where(it => (it as BaseDatabaseData).Uid == uid).First();
                }
            }
            catch (Exception e)
            {
                logger.Error("Unsupported type", e);
                return null;
            }
        }

        public List<T>? GetAllInstance<T>() where T : class, new()
        {
            try
            {
                lock (_lock)
                {
                    return sqlSugarScope?.Queryable<T>().ToList();
                }
            } catch(Exception e)
            {
                logger.Error("Unsupported type", e);
                return null;
            }
        }

        public void SaveInstance<T>(T instance) where T : class, new()
        {
            lock (_lock)
            {
                sqlSugarScope?.Insertable(instance).ExecuteCommand();
            }
        }

        public void UpdateInstance<T>(T instance) where T : class, new()
        {
            lock (_lock)
            {
                sqlSugarScope?.Updateable(instance).ExecuteCommand();
            }
        }

        public void DeleteInstance<T>(T instance) where T : class, new()
        {
            lock (_lock)
            {
                sqlSugarScope?.Deleteable(instance).ExecuteCommand();
            }
        }
    }
}
