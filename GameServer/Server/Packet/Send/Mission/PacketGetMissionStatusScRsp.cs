using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Mission
{
    public class PacketGetMissionStatusScRsp : BasePacket
    {
        public PacketGetMissionStatusScRsp(GetMissionStatusCsReq req) : base(CmdIds.GetMissionStatusScRsp)
        {
            var proto = new GetMissionStatusScRsp();

            foreach (var item in req.MainMissionIdList)
            {
                proto.FinishedMainMissionIdList.Add(item);
            }

            foreach (var item in req.SubMissionIdList)
            {
                proto.SubMissionStatusList.Add(new Proto.Mission()
                {
                    Id = item,
                    Status = MissionStatus.MissionFinish,
                });
            }

            SetData(proto);
        }
    }
}
