using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Player;

namespace EggLink.DanhengServer.Server.Packet.Recv.Player
{
    [Opcode(CmdIds.SetPlayerInfoCsReq)]
    public class HandlerSetPlayerInfoCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var player = connection.Player!;
            var req = SetPlayerInfoCsReq.Parser.ParseFrom(data);
            if (req == null) return;
            player.Data.CurrentGender = req.Gender;
            player.Data.Name = req.Nickname;
            if (req.Gender == Gender.Woman)  
            {
                player.Data.CurBasicType = 8002;
                player.AddAvatar(8002);
                DatabaseHelper.Instance?.UpdateInstance(player.Data);
            } else
            {
                player.Data.CurBasicType = 8001;
                player.AddAvatar(8001);
                DatabaseHelper.Instance?.UpdateInstance(player.Data);
            }
            player.AddAvatar(1001);
            player.LineupManager!.AddAvatarToCurTeam(8001);
            player.LineupManager!.AddAvatarToCurTeam(1001);
            player.MissionManager!.GetRunningSubMissionIdList().ForEach(player.MissionManager.FinishSubMission);

            connection.SendPacket(new PacketSetPlayerInfoScRsp(player, req.IsModify));
            connection.SendPacket(new PacketPlayerSyncScNotify(player.ToProto()));
        }
    }
}
