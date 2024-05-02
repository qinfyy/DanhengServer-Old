using System.Text;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("mission", "Get the running missions or finish the mission", "/mission <finish [submissionId]>/<running>")]
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

        [CommandMethod("0 finish")]
        public void FinishRunningMission(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found.");
                return;
            }

            if (arg.BasicArgs.Count < 1)
            {
                arg.SendMsg("Please specify the mission id.");
                return;
            }

            if (!int.TryParse(arg.BasicArgs[0], out var missionId))
            {
                arg.SendMsg("Invalid mission id.");
                return;
            }

            var mission = arg.Target!.Player!.MissionManager!;
            //mission.AcceptSubMission(missionId);  // if not accepted, the mission will not be finished
            mission.FinishSubMission(missionId);
            arg.SendMsg("Finish mission.");
        }

        [CommandMethod("0 running")]
        public void ListRunningMission(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found.");
                return;
            }

            var mission = arg.Target!.Player!.MissionManager!;
            var runningMissions = mission.GetRunningSubMissionIdList();
            if (runningMissions.Count == 0)
            {
                arg.SendMsg("No running missions.");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("Running missions:");
            foreach (var missionId in runningMissions)
            {
                sb.AppendLine(missionId.ToString());
            }

            arg.SendMsg(sb.ToString());
        }
    }
}
