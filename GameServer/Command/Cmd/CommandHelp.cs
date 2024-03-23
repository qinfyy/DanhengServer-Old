using EggLink.DanhengServer.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("help", "Show the help message", "/help")]
    public class CommandHelp : ICommand
    {
        [CommandDefault]
        public void Help(CommandArg arg)
        {
            var commands = EntryPoint.CommandManager.CommandInfo.Values;
            arg.SendMsg("Commands:");
            foreach (var command in commands)
            {
                arg.SendMsg($"/{command.Name} - {command.Description}\nUsage: {command.Usage}");
            }
        }
    }
}
