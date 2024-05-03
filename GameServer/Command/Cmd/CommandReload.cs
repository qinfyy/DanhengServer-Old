using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("reload", "Reload the banners", "/reload", permission:"egglink.manage")]
    public class CommandReload : ICommand
    {
        [CommandDefault]
        public void Reload(CommandArg arg)
        {
            // Reload the banners
            GameData.BannersConfig = ResourceManager.LoadCustomFile<BannersConfig>("Banner", "Banners") ?? new();
            arg.SendMsg("Banners reloaded");
        }
    }
}
