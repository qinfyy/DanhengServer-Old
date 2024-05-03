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
                    HandleCommand(input, new ConsoleCommandSender(Logger));
                }
                catch
                {
                    Logger.Error($"An error happened when execute command");
                }
            }
        }

        public void HandleCommand(string input, ICommandSender sender)
        {
            try
            {
                var cmd = input.Split(' ')[0];

                var tempTarget = Target;
                if (sender is ConsoleCommandSender)
                {
                    if (cmd.StartsWith('@'))
                    {
                        var target = cmd[1..];
                        var con = Listener.Connections.Values.ToList().Find(item => item.Player?.Uid.ToString() == target);
                        if (con != null)
                        {
                            Target = con;
                            sender.SendMsg($"Online player {target}({con.Player!.Data.Name}) is found, the next command will target it by default.");
                        }
                        else
                        {
                            // offline or not exist
                            sender.SendMsg($"Target {target} is offline or not found.");
                        }
                        return;
                    }
                } else if (sender is PlayerCommandSender player)
                {
                    // player
                    tempTarget = player.Player.Connection;
                }

                if (tempTarget != null && !tempTarget.IsOnline)
                {
                    sender.SendMsg($"Target {tempTarget.Player!.Uid}({tempTarget.Player!.Data.Name}) is offline.");
                    tempTarget = null;
                }

                if (Commands.TryGetValue(cmd, out var command))
                {
                    var split = input.Split(' ').ToList();
                    split.RemoveAt(0);

                    var arg = new CommandArg(split.JoinFormat(" ", ""), sender, tempTarget);
                    // find the proper method with attribute CommandMethod
                    var isFound = false;
                    CommandInfo info = CommandInfo[cmd];

                    if (!sender.HasPermission(info.Permission))
                    {
                        sender.SendMsg("You don't have permission to execute this command.");
                        return;
                    }

                    foreach (var method in command.GetType().GetMethods())
                    {
                        var attr = method.GetCustomAttribute<CommandMethod>();
                        if (attr != null)
                        {
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
                                sender.SendMsg($"Usage: {info.Usage}");
                            }
                            else
                            {
                                sender.SendMsg($"Command \"{cmd}\" not found.");
                            }
                        }
                    }
                }
                else
                {
                    sender.SendMsg($"Command \"{cmd}\" not found.");
                }
            }
            catch
            {
                sender.SendMsg($"An error happened when execute command");
            }
        }
    }
}
