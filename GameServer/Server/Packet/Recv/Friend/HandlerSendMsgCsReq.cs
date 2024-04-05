using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Friend;
using EggLink.DanhengServer.Server.Packet.Send.Gacha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Recv.Friend
{
    [Opcode(CmdIds.SendMsgCsReq)]
    public class HandlerSendMsgCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = SendMsgCsReq.Parser.ParseFrom(data);

            if (req.MessageType == MsgType.CustomText)
            {
                connection.SendPacket(new PacketRevcMsgScNotify(req.PPDPMFPJFPB[0], connection.Player!.Uid, req.MessageText));
            }
            else if (req.MessageType == MsgType.Emoji)
            {
                connection.SendPacket(new PacketRevcMsgScNotify(req.PPDPMFPJFPB[0], connection.Player!.Uid, req.ExtraId));
            }

            // TODO: command execution

            connection.SendPacket(CmdIds.SendMsgScRsp);
        }
    }
}
