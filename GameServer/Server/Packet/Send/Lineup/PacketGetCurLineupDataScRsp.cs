using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Lineup
{
    public class PacketGetCurLineupDataScRsp : BasePacket
    {
        public PacketGetCurLineupDataScRsp(PlayerInstance player) : base(CmdIds.GetCurLineupDataScRsp)
        {
            var data = new GetCurLineupDataScRsp()
            {
                Lineup = player.LineupManager.GetCurLineup()!.ToProto(),
            };

            SetData(data);
        }
    }
}
