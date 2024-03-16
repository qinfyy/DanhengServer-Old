using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Mission;

namespace EggLink.DanhengServer.Server.Packet.Recv.Mission
{
    [Opcode(CmdIds.FinishTalkMissionCsReq)]
    public class HandlerFinishTalkMissionCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = FinishTalkMissionCsReq.Parser.ParseFrom(data);
            var player = connection.Player!;
            var missionId = int.Parse(req.TalkStr.Split('_')[1]);
            player.MissionManager!.FinishSubMission(missionId);

            connection.SendPacket(new PacketFinishTalkMissionScRsp(req.TalkStr));
        }
    }
}
