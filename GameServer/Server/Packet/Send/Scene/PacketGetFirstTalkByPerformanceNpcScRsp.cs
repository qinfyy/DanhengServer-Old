using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Scene
{
    public class PacketGetFirstTalkByPerformanceNpcScRsp : BasePacket
    { 
        public PacketGetFirstTalkByPerformanceNpcScRsp(GetFirstTalkByPerformanceNpcCsReq req) : base(CmdIds.GetFirstTalkByPerformanceNpcScRsp)
        {
            var rsp = new GetFirstTalkByPerformanceNpcScRsp();

            foreach (var id in req.NpcTalkList)
            {
                rsp.NpcTalkInfoList.Add(new NpcTalkInfo
                {
                    MeetId = id,
                });
            }

            SetData(rsp);
        }
    }
}
