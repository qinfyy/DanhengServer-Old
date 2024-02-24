using EggLink.DanhengServer.Util;
using Microsoft.Data.Sqlite;

namespace EggLink.DanhengServer.Database.Account
{
    [DatabaseEntity("account")]
    public class AccountData(string username, long uid, string comboToken = "", string dispatchToken = "", string permissions = "") : BaseDatabaseData
    {
        public string Username { get; set; } = username;
        public long Uid { get; set; } = uid;
        public string ComboToken { get; set; } = comboToken;
        public string DispatchToken { get; set; } = dispatchToken;
        public string Permissions { get; set; } = permissions;  // type: permission1,permission2,permission3...

        public static BaseDatabaseData? GetAccountByUserName(string username)
        {
            var connection = DatabaseHelper.Instance.connection;
            var command = new SqliteCommand("SELECT * FROM account", connection);
            var reader = command.ExecuteReader();
            AccountData? result = null;
            while (reader.Read())
            {
                if (reader.GetString(0) == username)
                {
                    result = new(reader.GetString(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    break;
                }
            }
            return result;
        }

        public static BaseDatabaseData? GetAccountByUid(long uid)
        {
            var connection = DatabaseHelper.Instance.connection;
            var command = new SqliteCommand("SELECT * FROM account", connection);
            var reader = command.ExecuteReader();
            AccountData? result = null;
            while (reader.Read())
            {
                if (reader.GetInt64(1) == uid)
                {
                    result = new(reader.GetString(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    break;
                }
            }
            return result;
        }

        public string GenerateDispatchToken()
        {
            DispatchToken = Crypto.CreateSessionKey(Uid.ToString());
            ModifyDatabase(Uid, "dispatchToken", DispatchToken);
            return DispatchToken;
        }
        
        public string GenerateComboToken()
        {
            ComboToken = Crypto.CreateSessionKey(Uid.ToString());
            ModifyDatabase(Uid, "comboToken", ComboToken);
            return ComboToken;
        }
    }
}
