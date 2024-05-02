using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Rogue.Scene.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("rogue", "Manage the resource in rogue", "/rogue <money [money]>/<buff [id/-1]>/<miracle [id]>/<enhance [id/-1]>/<unstuck>")]
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
            arg.Target.Player!.RogueManager!.GetRogueInstance()?.GainMoney(count);
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
                arg.Target.Player!.RogueManager!.GetRogueInstance()?.AddBuffList(buffList);
                arg.SendMsg("Player has gained all buffs");
            }
            else
            {
                arg.Target.Player!.RogueManager!.GetRogueInstance()?.AddBuff(id);
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
            
            arg.Target.Player!.RogueManager!.GetRogueInstance()?.AddMiracle(id);
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
                    arg.Target.Player!.RogueManager!.GetRogueInstance()?.EnhanceBuff(enhance.MazeBuffID);
                }
                arg.SendMsg("Player has gained all enhances");
            }
            else
            {
                arg.Target.Player!.RogueManager!.GetRogueInstance()?.EnhanceBuff(id);
                arg.SendMsg($"Player has gained enhance {id}");
            }
        }

        [CommandMethod("0 unstuck")]
        public void Unstuck(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }

            var player = arg.Target.Player!;
            foreach (var npc in player.SceneInstance!.Entities.Values)
            {
                if (npc is RogueNpc rNpc)
                {
                    if (rNpc.RogueNpcId > 0)
                    {
                        player.SceneInstance!.RemoveEntity(rNpc);
                    }
                }
            }

            arg.SendMsg("Player has been unstuck");
        }
    }
}
