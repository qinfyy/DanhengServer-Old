using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Friend
{
    public class PacketGetPrivateChatHistoryScRsp : BasePacket
    {
        public PacketGetPrivateChatHistoryScRsp(uint contactId) : base(CmdIds.GetPrivateChatHistoryScRsp)
        {
            var proto = new GetPrivateChatHistoryScRsp()
            {
                ContactId = contactId,
            };

            SetData(proto);
        }
    }
}
