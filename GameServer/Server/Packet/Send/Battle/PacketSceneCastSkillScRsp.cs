using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Battle
{
    public class PacketSceneCastSkillScRsp : BasePacket
    {
        public PacketSceneCastSkillScRsp() : base(CmdIds.SceneCastSkillScRsp)
        {

        }
    }
}
