using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Player
{
    public class PacketGetPlayerBoardDataScRsp : BasePacket
    {
        public PacketGetPlayerBoardDataScRsp(PlayerInstance player) : base(CmdIds.GetPlayerBoardDataScRsp)
        {
            var proto = new GetPlayerBoardDataScRsp()
            {
                CurrentHeadIconId = (uint)player.Data.HeadIcon,
                Signature = player.Data.Signature,
            };

            player.PlayerUnlockData.HeadIcons.ForEach(id =>
            {
                HeadIcon headIcon = new() { Id = (uint)id };
                proto.UnlockedHeadIconList.Add(headIcon);
            });

            proto.DisplayAvatarVec = new();
            var pos = 0;
            player.AvatarManager.AvatarData.DisplayAvatars.ForEach(avatar =>
            {
                DisplayAvatar displayAvatar = new()
                {
                    AvatarId = (uint)avatar,
                    Pos = (uint)pos++,
                };
                proto.DisplayAvatarVec.DisplayAvatarList.Add(displayAvatar);
            });

            SetData(proto);
        }
    }
}
