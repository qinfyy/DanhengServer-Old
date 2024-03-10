using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Lineup
{
    public class PacketSyncLineupNotify : BasePacket
    {
        public PacketSyncLineupNotify(Database.Lineup.LineupInfo info) : base(CmdIds.SyncLineupNotify)
        {
            var proto = new SyncLineupNotify()
            {
                Lineup = info.ToProto(),
            };

            SetData(proto);
        }
    }
}
