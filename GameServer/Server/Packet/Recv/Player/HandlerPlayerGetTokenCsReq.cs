using EggLink.DanhengServer.Common.Enums;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Server.Packet.Recv.Player
{
    [Opcode(CmdIds.PlayerGetTokenCsReq)]
    public class HandlerPlayerGetTokenCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = PlayerGetTokenCsReq.Parser.ParseFrom(data);
            connection.State = SessionState.WAITING_FOR_LOGIN;
            var pd = DatabaseHelper.Instance?.GetInstance<PlayerData>(long.Parse(req.AccountUid));
            if (pd == null)
                connection.Player = new PlayerInstance() 
                { 
                    Uid = ushort.Parse(req.AccountUid),
                };
            else
            {
                connection.Player = new PlayerInstance(pd);
            }
            connection.Player.OnLogin();
            connection.Player.Connection = connection;
            connection.SendPacket(new PacketPlayerGetTokenScRsp(connection));
        }
    }
}
