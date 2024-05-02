namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("give", "Give item to player", "give <item> l<level> x<amount> r<rank>")]
    public class CommandGive : ICommand
    {
        [CommandDefault]
        public void GiveItem(CommandArg arg)
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

            if (arg.BasicArgs.Count == 0)
            {
                arg.SendMsg("Item not found.");
                return;
            }

            arg.CharacterArgs.TryGetValue("x", out var str);
            arg.CharacterArgs.TryGetValue("l", out var levelStr);
            arg.CharacterArgs.TryGetValue("r", out var rankStr);
            str ??= "1";
            levelStr ??= "1";
            rankStr ??= "1";
            if (!int.TryParse(str, out var amount) || !int.TryParse(levelStr, out var level) || !int.TryParse(rankStr, out var rank))
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            player.InventoryManager!.AddItem(int.Parse(arg.BasicArgs[0]), amount, rank: Math.Min(rank, 5), level: Math.Max(Math.Min(level, 80), 1));
            arg.SendMsg($"Give @{player.Uid} {amount} items of {arg.BasicArgs[0]}");
        }
    }
}
