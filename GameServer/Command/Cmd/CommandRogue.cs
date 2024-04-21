using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("rogue", "Manage the resource in rogue", "/rogue <money [money]>/<buff [id/-1]>/<miracle [id]>/<enhance [id/-1]>")]
    public class CommandRogue : ICommand
    {
        [CommandMethod("0 money")]
        public void GetMoney(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            var count = arg.GetInt(0);
            arg.Target.Player!.RogueManager!.RogueInstance?.GainMoney(count);
            arg.SendMsg($"Player has gained {count} money");
        }

        [CommandMethod("0 buff")]
        public void GetBuff(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            var id = arg.GetInt(0);
            if (id == -1)
            {
                var buffList = new List<RogueBuffExcel>();
                foreach (var buff in GameData.RogueBuffData.Values)
                {
                    if (buff.IsAeonBuff || buff.MazeBuffLevel == 2) continue;
                    buffList.Add(buff);
                }
                arg.Target.Player!.RogueManager!.RogueInstance?.AddBuffList(buffList);
                arg.SendMsg("Player has gained all buffs");
            }
            else
            {
                arg.Target.Player!.RogueManager!.RogueInstance?.AddBuff(id);
                arg.SendMsg($"Player has gained buff {id}");
            }
        }

        [CommandMethod("0 miracle")]
        public void GetMiracle(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            var id = arg.GetInt(0);
            
            arg.Target.Player!.RogueManager!.RogueInstance?.AddMiracle(id);
            arg.SendMsg($"Player has gained miracle {id}");
            
        }

        [CommandMethod("0 enhance")]
        public void GetEnhance(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            var id = arg.GetInt(0);
            if (id == -1)
            {
                foreach (var enhance in GameData.RogueBuffData.Values)
                {
                    arg.Target.Player!.RogueManager!.RogueInstance?.EnhanceBuff(enhance.MazeBuffID);
                }
                arg.SendMsg("Player has gained all enhances");
            }
            else
            {
                arg.Target.Player!.RogueManager!.RogueInstance?.EnhanceBuff(id);
                arg.SendMsg($"Player has gained enhance {id}");
            }
        }
    }
}
