using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Player
{
    public class PacketPlayerHeartBeatScRsp : BasePacket
    {
        public PacketPlayerHeartBeatScRsp(long clientTime) : base(CmdIds.PlayerHeartBeatScRsp)
        {
            var data = new PlayerHeartBeatScRsp()
            {
                ClientTimeMs = (ulong)clientTime,
                ServerTimeMs = (ulong)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond),
            };

            SetData(data);
        }
    }
}
