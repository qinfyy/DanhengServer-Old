using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Mission;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Mission
{
    public class MissionManager : BasePlayerManager
    {
        public MissionData Data;
        public MissionManager(PlayerInstance player) : base(player)
        {
            var mission = DatabaseHelper.Instance?.GetInstance<MissionData>(player.Uid);
            if (mission == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new MissionData()
                {
                    Uid = player.Uid,
                });
                mission = DatabaseHelper.Instance?.GetInstance<MissionData>(player.Uid);
            }
            Data = mission!;
        }

        public MissionPhaseEnum GetMissionStatus(int missionId)
        {
            if (Data.MissionInfo.TryGetValue(missionId, out var info))
            {
                return info.Status;
            }
            return MissionPhaseEnum.None;
        }
    }
}
