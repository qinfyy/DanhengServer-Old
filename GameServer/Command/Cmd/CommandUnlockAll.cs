using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Server.Packet.Send.Player;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("unlockall", "Unlock all the things in that category", "/unlockall <mission/scene>")]
    public class CommandUnlockAll : ICommand
    {
        [CommandMethod("0 mission")]
        public void UnlockAllMissions(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found!");
                return;
            }
            var player = arg.Target!.Player!;
            var missionManager = player.MissionManager!;

            foreach (var mission in GameData.SubMissionData.Values)
            {
                if (!missionManager.Data.MissionInfo.TryGetValue(mission.MainMissionID, out Dictionary<int, Database.Mission.MissionInfo>? value))
                {
                    value = ([]);
                    missionManager.Data.MissionInfo[mission.MainMissionID] = value;
                }

                value[mission.SubMissionID] = new Database.Mission.MissionInfo()
                {
                    Status = Enums.MissionPhaseEnum.Finish,
                    MissionId = mission.SubMissionID,
                };
            }

            foreach (var mission in GameData.MainMissionData.Values)
            {
                missionManager.Data.MainMissionInfo[mission.MainMissionID] = Enums.MissionPhaseEnum.Finish;
            }

            arg.SendMsg("All missions unlocked!");
            arg.Target!.Player!.SendPacket(new PacketPlayerKickOutScNotify());
            arg.Target!.Stop();
        }

        [CommandMethod("0 scene")]
        public void UnlockAllScenes(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found!");
                return;
            }
            var player = arg.Target!.Player!;
            var scene = player.SceneInstance!;
            foreach (var prop in scene.Entities)
            {
                if (prop.Value is EntityProp propInstance)
                {
                    player.InteractProp(propInstance.EntityID, 1010);
                }
            }
            arg.SendMsg("The props in current scene are unlocked!");
        }
    }
}
