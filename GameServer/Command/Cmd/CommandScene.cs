using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("scene", "", "")]
    public class CommandScene : ICommand
    {
        [CommandMethod("0 group")]
        public void GetLoadedGroup(CommandArg arg)
        {
            var scene = arg.Target!.Player!.SceneInstance!;
            var loadedGroup = new List<int>();
            foreach (var group in scene.Entities)
            {
                if (!loadedGroup.Contains(group.Value.GroupID))
                {
                    loadedGroup.Add(group.Value.GroupID);
                }
            }
            arg.SendMsg($"Loaded groups: {string.Join(", ", loadedGroup)}");
        }

        [CommandMethod("0 pass")]  // temp  should be moved to mission
        public void PassRunningMission(CommandArg arg)
        {
            var mission = arg.Target!.Player!.MissionManager!;
            mission.GetRunningSubMissionIdList().ForEach(mission.AcceptSubMission);
        }
    }
}
