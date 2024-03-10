using EggLink.DanhengServer.Server.Packet.Send.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Recv.Battle
{
    [Opcode(CmdIds.SceneCastSkillCsReq)]
    public class HandlerSceneCastSkillCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            connection.SendPacket(new PacketSceneCastSkillScRsp());
        }
    }
}
