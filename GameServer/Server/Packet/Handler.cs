using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet
{
    public abstract class Handler
    {
        public abstract void OnHandle(byte[] header, byte[] data);
    }
}
