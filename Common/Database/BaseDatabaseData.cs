using Microsoft.Data.Sqlite;

namespace EggLink.DanhengServer.Database
{
    public abstract class BaseDatabaseData
    {
        public void SaveToDatabase()
        {
            var connection = DatabaseHelper.Instance.connection;
            var attributes = GetType().GetCustomAttributes(true);
            string tableName = "";
            foreach ( var attribute in attributes )
            {
                if (attribute is DatabaseEntity)
                {
                    tableName = (attribute as DatabaseEntity).TableName;
                    break;
                }
            }
            var command = new SqliteCommand($"INSERT INTO {tableName} (", connection);
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                command.CommandText += $"{property.Name}, ";
            }
            command.CommandText = command.CommandText[..^2];
            command.CommandText += ") VALUES (";
            foreach (var property in properties)
            {
                command.CommandText += $"\"{property.GetValue(this)}\", ";
            }
            command.CommandText = command.CommandText[..^2];
            command.CommandText += ")";
            command.ExecuteNonQuery();
        }

        public void ModifyDatabase(long uid, string property, string value)
        {
            var connection = DatabaseHelper.Instance.connection;
            var attributes = GetType().GetCustomAttributes(true);
            string tableName = "";
            foreach ( var attribute in attributes )
            {
                if (attribute is DatabaseEntity)
                {
                    tableName = (attribute as DatabaseEntity).TableName;
                    break;
                }
            }
            var command = new SqliteCommand($"UPDATE {tableName} SET \"{property}\" = \"{value}\" WHERE UID = {uid};", connection);
            command.ExecuteNonQuery();
        }

        public void DeleteFromDatabase()
        {
            var connection = DatabaseHelper.Instance.connection;
            var attributes = GetType().GetCustomAttributes(true);
            string tableName = "";
            foreach ( var attribute in attributes )
            {
                if (attribute is DatabaseEntity)
                {
                    tableName = (attribute as DatabaseEntity).TableName;
                    break;
                }
            }
            var command = new SqliteCommand($"DELETE FROM {tableName} WHERE ", connection);
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                command.CommandText += $"{property.Name} = {property.GetValue(this)} AND ";
            }
            command.CommandText = command.CommandText[..^5];
            command.ExecuteNonQuery();
        }
    }
}
