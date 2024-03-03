using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Player
{
    public class PacketPlayerSyncScNotify : BasePacket
    {
        public PacketPlayerSyncScNotify() : base(CmdIds.PlayerSyncScNotify)
        {

        }
    }
}
