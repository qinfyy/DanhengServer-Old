using EggLink.DanhengServer.Command;
using EggLink.DanhengServer.Program;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Friend;
using EggLink.DanhengServer.Server.Packet.Send.Gacha;
using EggLink.DanhengServer.Util;
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
                connection.SendPacket(new PacketRevcMsgScNotify(req.TargetList[0], connection.Player!.Uid, req.MessageText));
            }
            else if (req.MessageType == MsgType.Emoji)
            {
                connection.SendPacket(new PacketRevcMsgScNotify(req.TargetList[0], connection.Player!.Uid, req.ExtraId));
            }

            // TODO: command execution
            if (req.TargetList[0] == ConfigManager.Config.ServerOption.ServerProfile.Uid)
            {
                if (req.MessageText.StartsWith('/'))
                {
                    var cmd = req.MessageText[1..];
                    EntryPoint.CommandManager.HandleCommand(cmd, new PlayerCommandSender(connection.Player!));
                }
            }

            connection.SendPacket(CmdIds.SendMsgScRsp);
        }
    }
}
