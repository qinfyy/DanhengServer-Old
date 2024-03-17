using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Lineup;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Lineup
{
    public class LineupManager : BasePlayerManager
    {
        public LineupData LineupData { get; private set; }
        public Dictionary<int, LineupInfo>  LineupInfo { get; private set; }

        public LineupManager(PlayerInstance player) : base(player)
        {
            var lineup = DatabaseHelper.Instance?.GetInstance<LineupData>(player.Uid);
            if (lineup == null)
            {
                LineupData = new()
                {
                    Uid = player.Uid,
                    CurLineup = 1,
                };
                DatabaseHelper.Instance?.SaveInstance(LineupData);
            }
            else
            {
                LineupData = lineup;
                if (LineupData.Lineups != null)
                {
                    foreach (var lineupInfo in LineupData.Lineups?.Values!)
                    {
                        lineupInfo.LineupData = LineupData;
                        lineupInfo.AvatarData = player.AvatarManager!.AvatarData;
                    }
                }
            }
            LineupInfo = LineupData.Lineups ?? [];
        }

        public LineupInfo? GetLineup(int lineupIndex)
        {
            LineupInfo.TryGetValue(lineupIndex, out var lineup);
            return lineup;
        }

        public LineupInfo? GetCurLineup()
        {
            return GetLineup(LineupData.CurLineup);
        }

        public void SetCurLineup(int lineupIndex)
        {
            if (lineupIndex < 0 || !LineupInfo.ContainsKey(lineupIndex))
            {
                return;
            }
            LineupData.CurLineup = lineupIndex;
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
        }

        public void AddAvatar(int lineupIndex, int avatarId)
        {
            if (lineupIndex < 0)
            {
                return;
            }
            LineupInfo.TryGetValue(lineupIndex, out LineupInfo? lineup);
            if (lineup == null)
            {
                lineup = new()
                {
                    Name = "Lineup " + lineupIndex,
                    LineupType = 0,
                    BaseAvatars = [new() { BaseAvatarId = avatarId }],
                    LineupData = LineupData,
                    AvatarData = Player.AvatarManager!.AvatarData,
                };
                LineupInfo.Add(lineupIndex, lineup);
            } else
            {
                lineup.BaseAvatars?.Add(new() { BaseAvatarId = avatarId });
                LineupInfo[lineupIndex] = lineup;
            }
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
        }

        public void AddAvatarToCurTeam(int avatarId)
        {
            AddAvatar(LineupData.CurLineup, avatarId);
        }

        public void AddSpecialAvatarToCurTeam(int specialAvatarId)
        {
            LineupInfo.TryGetValue(LineupData.CurLineup, out LineupInfo? lineup);
            GameData.SpecialAvatarData.TryGetValue(specialAvatarId, out var specialAvatar);
            if (specialAvatar == null)
            {
                return;
            }
            if (lineup == null)
            {
                lineup = new()
                {
                    Name = "Lineup " + LineupData.CurLineup,
                    LineupType = 0,
                    BaseAvatars = [new() { BaseAvatarId = specialAvatar.AvatarID, SpecialAvatarId = specialAvatarId }],
                    LineupData = LineupData,
                    AvatarData = Player.AvatarManager!.AvatarData,
                };
                LineupInfo.Add(LineupData.CurLineup, lineup);
            } else
            {
                lineup.BaseAvatars?.Add(new() { BaseAvatarId = specialAvatar.AvatarID, SpecialAvatarId = specialAvatarId });
                LineupInfo[LineupData.CurLineup] = lineup;
            }
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
        }
    }
}
