using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("lineup", "manage the player's lineup", "/lineup")]
    public class CommandLineup : ICommand
    {
        [CommandMethod("0 mp")]
        public void SetLineupMp(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            var count = arg.GetInt(0);
            arg.Target.Player!.LineupManager!.GainMp(count == 0 ? 2: count);
            arg.SendMsg($"Player has gained {count} MP");
        }
    }
}
