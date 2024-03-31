using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Tutorial
{
    public class PacketFinishTutorialGuideScRsp : BasePacket
    {
        public PacketFinishTutorialGuideScRsp(uint tutorialId) : base(CmdIds.FinishTutorialGuideScRsp)
        {
            var rsp = new FinishTutorialGuideScRsp
            {
                TutorialGuide = new ()
                {
                    Id = tutorialId,
                    Status = TutorialStatus.TutorialFinish,
                }
            };

            SetData(rsp);
        }
    }
}
