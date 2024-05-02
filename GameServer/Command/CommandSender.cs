using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Server.Packet.Send.Friend;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command
{
    public interface ICommandSender
    {
        public void SendMsg(string msg);
    }

    public class ConsoleCommandSender(Logger logger) : ICommandSender
    {
        public void SendMsg(string msg)
        {
            logger.Info(msg);
        }
    }

    public class PlayerCommandSender(PlayerInstance player) : ICommandSender
    {
        public PlayerInstance Player = player;

        public void SendMsg(string msg)
        {
            Player.SendPacket(new PacketRevcMsgScNotify(toUid:Player.Uid, fromUid: (uint)ConfigManager.Config.ServerOption.ServerProfile.Uid, msg));
        }
    }
}
