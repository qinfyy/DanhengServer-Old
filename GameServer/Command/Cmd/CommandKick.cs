using EggLink.DanhengServer.Server.Packet.Send.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("kick", "Kick the player from server", "/kick")]
    public class CommandKick : ICommand
    {
        [CommandDefault]
        public void Kick(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            arg.Target.SendPacket(new PacketPlayerKickOutScNotify());
            arg.SendMsg($"Player {arg.Target.Player!.Data.Name} has been kicked");
            arg.Target.Stop();
        }
    }
}
