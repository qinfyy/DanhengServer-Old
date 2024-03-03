namespace EggLink.DanhengServer.Server.Packet.Recv.Player
{
    [Opcode(CmdIds.PlayerLoginFinishCsReq)]
    public class HandlerPlayerLoginFinishCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            connection.SendPacket(CmdIds.PlayerLoginFinishScRsp);
            connection.SendPacket(CmdIds.GetArchiveDataScRsp);
        }
    }
}
