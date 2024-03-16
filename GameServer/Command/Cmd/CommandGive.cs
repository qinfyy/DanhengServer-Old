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
            arg.CharacterArgs.TryGetValue("x", out var str);
            if (str == null) str = "1";

            player.InventoryManager!.AddItem(int.Parse(arg.BasicArgs[0]), int.Parse(str));
            arg.SendMsg($"Give @{player.Uid} item of {arg.BasicArgs[0]}");
        }
    }
}
