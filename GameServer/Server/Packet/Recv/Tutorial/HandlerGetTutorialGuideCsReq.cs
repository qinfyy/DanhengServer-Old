using EggLink.DanhengServer.Server.Packet.Send.Tutorial;

namespace EggLink.DanhengServer.Server.Packet.Recv.Tutorial
{
    [Opcode(CmdIds.GetTutorialGuideCsReq)]
    public class HandlerGetTutorialGuideCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            //connection.SendPacket(new PacketGetTutorialGuideScRsp(connection.Player!));  // somebug
        }
    }
}
