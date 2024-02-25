using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet
{
    public class BasePacket
    {
        public int CmdId;

        public byte[] BuildPacket()
        {
            return [];
        }
    }
}
