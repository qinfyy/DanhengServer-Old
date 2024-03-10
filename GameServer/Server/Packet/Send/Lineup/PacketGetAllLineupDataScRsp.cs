using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.Lineup
{
    public class PacketGetAllLineupDataScRsp : BasePacket
    {
        public PacketGetAllLineupDataScRsp(PlayerInstance player) : base(CmdIds.GetAllLineupDataScRsp)
        {
            var proto = new GetAllLineupDataScRsp()
            {
                CurIndex = (uint)(player.LineupManager.LineupData.CurLineup - 1),
            };
            foreach (var lineup in player.LineupManager.LineupInfo.Values)
            {
                proto.LineupList.Add(lineup.ToProto());
            }

            SetData(proto);
        }
    }
}
