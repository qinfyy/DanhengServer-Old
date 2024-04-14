using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Rogue
{
    public class PacketSyncRogueStatusScNotify : BasePacket
    {
        public PacketSyncRogueStatusScNotify() : base(CmdIds.SyncRogueStatusScNotify)
        {
            var proto = new SyncRogueStatusScNotify()
            {
                Status = RogueStatus.Finish,
            };

            SetData(proto);
        }
    }
}
