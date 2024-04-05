using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Program;
using EggLink.DanhengServer.Server;
using EggLink.DanhengServer.Util;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command
{
    public class CommandManager
    {
        public Dictionary<string, ICommand> Commands { get; } = [];
        public Dictionary<string, CommandInfo> CommandInfo { get; } = [];
        public Logger Logger { get; } = new Logger("CommandManager");
        public Connection? Target { get; set; } = null;

        public void RegisterCommand()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attr = type.GetCustomAttribute<CommandInfo>();
                if (attr != null)
                {
                    var instance = Activator.CreateInstance(type);
                    if (instance is ICommand command)
                    {
                        Commands.Add(attr.Name, command);
                        CommandInfo.Add(attr.Name, attr);
                    }
                }
            }
            Logger.Info($"Register {Commands.Count} commands.");
        }

        public void Start()
        {
            while (true)
            {
                try
                {

                    string? input = AnsiConsole.Ask<string>("> ");
                    if (string.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    var cmd = input.Split(' ')[0];
                    if (cmd.StartsWith('@'))
                    {
                        var target = cmd[1..];
                        var con = Listener.Connections.Values.ToList().Find(item => item.Player?.Uid.ToString() == target);
                        if (con != null)
                        {
                            Target = con;
                            Logger.Info($"Online player {target}({con.Player!.Data.Name}) is found, the next command will target it by default.");
                        }
                        else
                        {
                            // offline or not exist
                            Logger.Warn($"Target {target} is offline or not found.");
                        }
                        continue;
                    }
                    if (Target != null && !Target.IsOnline)
                    {
                        Logger.Warn($"Target {Target.Player!.Uid}({Target.Player!.Data.Name}) is offline.");
                        Target = null;
                    }
                    if (Commands.TryGetValue(cmd, out var command))
                    {
                        var split = input.Split(' ').ToList();
                        split.RemoveAt(0);

                        var arg = new CommandArg(split.JoinFormat(" ", ""), new ConsoleCommandSender(Logger), Target);
                        // find the proper method with attribute CommandMethod
                        var isFound = false;
                        CommandInfo? info = null;
                        foreach (var method in command.GetType().GetMethods())
                        {
                            var attr = method.GetCustomAttribute<CommandMethod>();
                            if (attr != null)
                            {
                                info = CommandInfo[cmd];
                                var canRun = true;
                                foreach (var condition in attr.Conditions)
                                {
                                    if (split.Count <= condition.Index)
                                    {
                                        canRun = false;
                                        break;
                                    }
                                    if (!split[condition.Index].Equals(condition.ShouldBe))
                                    {
                                        canRun = false;
                                        break;
                                    }
                                }
                                if (canRun)
                                {
                                    isFound = true;
                                    method.Invoke(command, [arg]);
                                    break;
                                }
                            }
                        }
                        if (!isFound)
                        {
                            // find the default method with attribute CommandDefault
                            foreach (var method in command.GetType().GetMethods())
                            {
                                var attr = method.GetCustomAttribute<CommandDefault>();
                                if (attr != null)
                                {
                                    isFound = true;
                                    method.Invoke(command, [arg]);
                                    break;
                                }
                            }
                            if (!isFound)
                            {
                                if (info != null)
                                {
                                    Logger.Info($"Usage: {info.Usage}");
                                } else
                                {
                                    Logger.Info($"Command \"{cmd}\" not found.");
                                }
                            }
                        }
                    }
                    else
                    {
                        Logger.Info($"Command \"{cmd}\" not found.");
                    }
                }
                catch
                {
                    Logger.Error($"An error happened when execute command");
                }
            }
        }
    }
}
