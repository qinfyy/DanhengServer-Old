using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Others
{
    public class PacketGetSecretKeyInfoScRsp : BasePacket
    {
        public PacketGetSecretKeyInfoScRsp() : base(CmdIds.GetSecretKeyInfoScRsp)
        {
            var proto = new GetSecretKeyInfoScRsp();
            proto.MCPPMIAFDBE.Add(new DGAKGPPBJIG()
            {
                Type = SecretKeyType.SecretKeyVideo,
                FFBANANOHPB = "10120425825329403",
            });

            SetData(proto);
        }
    }
}
