using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Lineup;

namespace EggLink.DanhengServer.Server.Packet.Recv.Lineup
{
    [Opcode(CmdIds.ChangeLineupLeaderCsReq)]
    public class HandlerChangeLineupLeaderCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = ChangeLineupLeaderCsReq.Parser.ParseFrom(data);
            var player = connection.Player!;
            if (player.LineupManager!.GetCurLineup() == null) return;
            var lineup = player.LineupManager!.GetCurLineup()!;
            var leaderAvatarId = lineup.BaseAvatars![(int)req.Slot].BaseAvatarId;
            lineup.LeaderAvatarId = leaderAvatarId;
            // save
            DatabaseHelper.Instance?.UpdateInstance(player.LineupManager!.LineupData);
            connection.SendPacket(new PacketChangeLineupLeaderScRsp(req.Slot));
        }
    }
}
