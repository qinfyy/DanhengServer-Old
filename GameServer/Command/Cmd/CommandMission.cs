namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("mission", "Manage the missions", "/mission <pass>")]
    public class CommandMission : ICommand
    {
        [CommandMethod("0 pass")]
        public void PassRunningMission(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found.");
                return;
            }
            var mission = arg.Target!.Player!.MissionManager!;
            mission.GetRunningSubMissionIdList().ForEach(mission.FinishSubMission);
            arg.SendMsg("Pass all running missions.");
        }
    }
}
