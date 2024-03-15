namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("give", "Give item to player", "give <item> l<level> r<rank> p<promotion> x<amount>")]
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
            
            
        }
    }
}
