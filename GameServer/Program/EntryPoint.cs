using EggLink.DanhengServer.Util;
using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Configuration;
using EggLink.DanhengServer.WebServer;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Server;
using EggLink.DanhengServer.Server.Packet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using EggLink.DanhengServer.Command;

namespace EggLink.DanhengServer.Program
{
    public class EntryPoint
    {
        private static Logger logger = new("Program");
        public static DatabaseHelper DatabaseHelper = new();
        public static Listener Listener = new();
        public static HandlerManager HandlerManager = new();
        public static CommandManager CommandManager = new();

        public static void Main(string[] args)
        {
            var time = DateTime.Now;
            // Initialize the logfile
            var counter = 0;
            FileInfo file;
            while (true)
            {
                file = new FileInfo(GetConfig().Path.LogPath + $"\\{DateTime.Now:yyyy-MM-dd}-{++counter}.log");
                if (!file.Exists && file.Directory != null)
                {
                    file.Directory.Create();
                    break;
                }
            }
            Logger.SetLogFile(file);
            // Starting the server
            logger.Info("Starting DanhengServer...");
            // Load the config
            logger.Info("Loading config...");
            try
            {
                ConfigManager.LoadConfig();
            } catch (Exception e)
            {
                logger.Error("Failed to load config", e);
                Console.ReadLine();
                return;
            }
            // Load the game data
            logger.Info("Loading game data...");
            try
            {
                ResourceManager.LoadGameData();
            } catch (Exception e)
            {
                logger.Error("Failed to load game data", e);
                Console.ReadLine();
                return;
            }
            // Initialize the database
            try
            {
                DatabaseHelper.Initialize();
            } catch (Exception e)
            {
                logger.Error("Failed to initialize database", e);
                Console.ReadLine();
                return;
            }
            try
            {
                CommandManager.RegisterCommand();
            } catch (Exception e)
            {
                logger.Error("Failed to initialize command manager", e);
                Console.ReadLine();
                return;
            }
            WebProgram.Main([$"--urls=http://{GetConfig().HttpServer.PublicAddress}:{GetConfig().HttpServer.PublicPort}/"]);
            logger.Info($"DispatchServer is running on http://{GetConfig().HttpServer.PublicAddress}:{GetConfig().HttpServer.PublicPort}/");

            Listener.StartListener();

            var elapsed = DateTime.Now - time;
            logger.Info($"Done in {elapsed.TotalSeconds.ToString()[..4]}s! Type '/help' to get help of commands.");

#if DEBUG
            JsonConvert.DeserializeObject<JObject>(File.ReadAllText("LogMap.json"))!.Properties().ToList().ForEach(x => Connection.LogMap.Add(x.Name, x.Value.ToString()));
#endif
            CommandManager.Start();
        }

        public static ConfigContainer GetConfig()
        {
            return ConfigManager.Config;
        }
    }
}
