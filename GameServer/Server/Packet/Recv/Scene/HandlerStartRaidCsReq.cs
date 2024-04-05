using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Recv.Scene
{
    [Opcode(CmdIds.StartRaidCsReq)]
    public class HandlerStartRaidCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = StartRaidCsReq.Parser.ParseFrom(data);
            var player = connection.Player!;
            GameData.RaidConfigData.TryGetValue((int)(req.RaidId * 100 + req.WorldLevel), out var raidConfig);
            if (raidConfig != null)
            {
                raidConfig.MainMissionIDList.ForEach(missionId =>
                {
                    player.MissionManager!.AcceptMainMission(missionId);
                });
                player.EnterScene(raidConfig.FinishEntranceID, 0, true);
            }
            connection.SendPacket(CmdIds.StartRaidScRsp);
        }
    }
}
