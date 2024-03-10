using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Avatar
{
    public class PacketGetHeroBasicTypeInfoScRsp : BasePacket
    {
        public PacketGetHeroBasicTypeInfoScRsp(PlayerInstance player) : base(CmdIds.GetHeroBasicTypeInfoScRsp)
        {
            var proto = new GetHeroBasicTypeInfoScRsp()
            {
                Gender = player.Data.CurrentGender ?? Gender.None,
                CurBasicType = (HeroBasicType)player.Data.CurBasicType,
            };

            SetData(proto);
        }
    }
}
