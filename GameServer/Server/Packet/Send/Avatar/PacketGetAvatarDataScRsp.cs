using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Avatar
{
    public class PacketGetAvatarDataScRsp : BasePacket
    {
        public PacketGetAvatarDataScRsp(PlayerInstance player) : base(CmdIds.GetAvatarDataScRsp)
        {
            var proto = new GetAvatarDataScRsp()
            {
                IsGetAll = true,
            };

            player.AvatarManager?.AvatarData?.Avatars?.ForEach(avatar =>
            {
                proto.AvatarList.Add(avatar.ToProto());
            });

            SetData(proto);
        }
    }
}
