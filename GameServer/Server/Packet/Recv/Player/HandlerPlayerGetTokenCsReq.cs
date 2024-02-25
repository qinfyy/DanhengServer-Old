using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Recv.Player
{
    [Opcode(CmdId.PlayerGetTokenCsReq)]
    public class HandlerPlayerGetTokenCsReq : Handler
    {
        public override void OnHandle(byte[] header, byte[] data)
        {
            var req = PlayerGetTokenCsReq.Parser.ParseFrom(data);
            Logger.GetByClassName().Debug("OnHandle" + req.ToString());
        }
    }
}
