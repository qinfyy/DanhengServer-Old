using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Lineup;
using EggLink.DanhengServer.Game.Player;
using Newtonsoft.Json;

namespace EggLink.DanhengServer.Game.Lineup
{
    public class LineupManager : BasePlayerManager
    {
        public LineupData LineupData { get; private set; }
        public LineupInfoJson LineupInfoJson { get; private set; }

        public LineupManager(PlayerInstance player) : base(player)
        {
            var lineup = DatabaseHelper.Instance?.GetInstance<LineupData>(player.Uid);
            if (lineup == null)
            {
                LineupData = new()
                {
                    Uid = player.Uid,
                    CurLineup = 0,
                    Lineups = "{}",
                };
                DatabaseHelper.Instance?.SaveInstance(LineupData);
            }
            else
            {
                LineupData = lineup;
            }
            LineupInfoJson = JsonConvert.DeserializeObject<LineupInfoJson>(LineupData.Lineups ?? "{}") ?? new();
        }

        public LineupInfo? GetLineup(int lineupIndex)
        {
            if (LineupData.Lineups == null)
            {
                return null;
            }
            if (lineupIndex < 0 || lineupIndex >= LineupInfoJson.Lineups?.Count)
            {
                return null;
            }
            return LineupInfoJson.Lineups?[lineupIndex];
        }

        public LineupInfo? GetCurLineup()
        {
            return GetLineup(LineupData.CurLineup);
        }

        public void SetCurLineup(int lineupIndex)
        {
            if (lineupIndex < 0 || lineupIndex >= LineupInfoJson.Lineups?.Count)
            {
                return;
            }
            LineupData.CurLineup = lineupIndex;
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
        }

        public void AddAvatar(int lineupIndex, int avatarId)
        {
            if (lineupIndex < 0 || LineupData == null)
            {
                return;
            }
            if (LineupData.Lineups == null)
            {
                LineupData.Lineups = "";
            }
            LineupInfo? lineup = null;
            LineupInfoJson.Lineups?.TryGetValue(lineupIndex, out lineup);
            if (lineup == null)
            {
                lineup = new()
                {
                    Name = "Lineup " + lineupIndex,
                    LineupType = 0,
                    BaseAvatars = [avatarId],
                };
                LineupInfoJson.Lineups?.Add(lineupIndex, lineup);
            } else
            {
                lineup.BaseAvatars?.Add(avatarId);
            }
            LineupData.Lineups = JsonConvert.SerializeObject(LineupInfoJson);
            DatabaseHelper.Instance?.UpdateInstance(LineupData!);
        }

        public void AddAvatarToCurTeam(int avatarId)
        {
            AddAvatar(LineupData.CurLineup, avatarId);
        }
    }
}
