using EggLink.DanhengServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("reload", "Reload the banners", "/reload")]
    public class CommandReload : ICommand
    {
        [CommandDefault]
        public void Reload(CommandArg arg)
        {
            // Reload the banners
            ResourceManager.LoadBanner();
            arg.SendMsg("Banners reloaded");
        }
    }
}
