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
}
