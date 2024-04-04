namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("give", "Give item to player", "give <item> l<level> x<amount>")]
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
            str ??= "1";
            if (!int.TryParse(str, out var amount))
            {
                arg.SendMsg("Invalid amount.");
                return;
            }

            player.InventoryManager!.AddItem(int.Parse(arg.BasicArgs[0]), amount);
            arg.SendMsg($"Give @{player.Uid} {amount} items of {arg.BasicArgs[0]}");
        }
    }
}
