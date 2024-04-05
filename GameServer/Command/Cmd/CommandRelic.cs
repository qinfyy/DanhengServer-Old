using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("relic", "Give the player relics", "/relic <artId> <mainAffixId> <subId1:level1> <subId2:level2> <subId3:level3> <subId4:level4> l<level> x<amount>")]
    public class CommandRelic : ICommand
    {
        [CommandDefault]
        public void GiveRelic(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var player = arg.Target.Player;
            if (player == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            if (arg.BasicArgs.Count < 3)
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            arg.CharacterArgs.TryGetValue("x", out var str);
            arg.CharacterArgs.TryGetValue("l", out var levelStr);
            str ??= "1";
            levelStr ??= "1";
            if (!int.TryParse(str, out var amount) || !int.TryParse(levelStr, out var level))
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            GameData.RelicConfigData.TryGetValue(int.Parse(arg.BasicArgs[0]), out var itemConfig);
            if (itemConfig == null)
            {
                arg.SendMsg("Item not found.");
                return;
            }

            GameData.RelicSubAffixData.TryGetValue(itemConfig.SubAffixGroup, out var subAffixConfig);
            GameData.RelicMainAffixData.TryGetValue(itemConfig.MainAffixGroup, out var mainAffixConfig);
            if (subAffixConfig == null || mainAffixConfig == null)
            {
                arg.SendMsg("Invalid item.");
                return;
            }
            int startIndex = 1;
            int mainAffixId;
            if (arg.BasicArgs[1].Contains(':'))
            {
                // random main affix
                mainAffixId = mainAffixConfig.Keys.ToList().RandomElement();
            } else
            {
                mainAffixId = int.Parse(arg.BasicArgs[1]);
                if (!mainAffixConfig.ContainsKey(mainAffixId))
                {
                    arg.SendMsg("Invalid main affix id.");
                    return;
                }
                startIndex++;
            }

            var remainLevel = 5;
            var subAffixes = new List<(int, int)>();
            for (var i = startIndex; i < arg.BasicArgs.Count; i++)
            {
                var subAffix = arg.BasicArgs[i].Split(':');
                if (subAffix.Length != 2 || !int.TryParse(subAffix[0], out var subId) || !int.TryParse(subAffix[1], out var subLevel))
                {
                    arg.SendMsg("Invalid arguments.");
                    return;
                }
                if (!subAffixConfig.ContainsKey(subId))
                {
                    arg.SendMsg("Invalid sub affix id.");
                    return;
                }
                subAffixes.Add((subId, subLevel));
                remainLevel -= subLevel - 1;
            }
            if (subAffixes.Count < 4)
            {
                // random sub affix
                var subAffixGroup = itemConfig.SubAffixGroup;
                var subAffixGroupConfig = GameData.RelicSubAffixData[subAffixGroup];
                var subAffixGroupKeys = subAffixGroupConfig.Keys.ToList();
                while (subAffixes.Count < 4)
                {
                    var subId = subAffixGroupKeys.RandomElement();
                    if (subAffixes.Any(x => x.Item1 == subId))
                    {
                        continue;
                    }
                    if (remainLevel <= 0)
                    {
                        subAffixes.Add((subId, 1));
                    } else
                    {
                        var subLevel = Random.Shared.Next(1, Math.Min(remainLevel + 1, 5)) + 1;
                        subAffixes.Add((subId, subLevel));
                        remainLevel -= subLevel - 1;
                    }
                }
            }


            var itemData = new ItemData()
            {
                ItemId = int.Parse(arg.BasicArgs[0]),
                Level = Math.Max(Math.Min(level, 15), 1),
                UniqueId = ++player.InventoryManager!.Data.NextUniqueId,
                MainAffix = mainAffixId,
                Count = 1,
            };

            foreach (var (subId, subLevel) in subAffixes)
            {
                subAffixConfig.TryGetValue(subId, out var subAffix);
                var aff = new ItemSubAffix(subAffix!, 1);
                for (var i = 1; i < subLevel; i++)
                {
                    aff.IncreaseStep(subAffix!.StepNum);
                }
                itemData.SubAffixes.Add(aff);
            }

            for (var i = 0; i < amount; i++)
            {
                player.InventoryManager!.AddItem(itemData);
            }


            arg.SendMsg($"Give @{player.Uid} {amount} relics of {mainAffixId}");
        }
    }
}
