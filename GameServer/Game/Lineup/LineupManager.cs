using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Lineup;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Server.Packet.Send.Lineup;

namespace EggLink.DanhengServer.Game.Lineup
{
    public class LineupManager : BasePlayerManager
    {
        public LineupData LineupData { get; private set; }

        public LineupManager(PlayerInstance player) : base(player)
        {
            LineupData = DatabaseHelper.Instance!.GetInstanceOrCreateNew<LineupData>(player.Uid);
            foreach (var lineupInfo in LineupData.Lineups.Values)
            {
                lineupInfo.LineupData = LineupData;
                lineupInfo.AvatarData = player.AvatarManager!.AvatarData;
            }
        }

        public LineupInfo? GetLineup(int lineupIndex)
        {
            LineupData.Lineups.TryGetValue(lineupIndex, out var lineup);
            return lineup;
        }

        public LineupInfo? GetCurLineup()
        {
            return GetLineup(LineupData.CurLineup);
        }

        public void SetCurLineup(int lineupIndex)
        {
            if (lineupIndex < 0 || !LineupData.Lineups.ContainsKey(lineupIndex))
            {
                return;
            }
            LineupData.CurLineup = lineupIndex;
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
        }

        public void AddAvatar(int lineupIndex, int avatarId, bool sendPacket = true)
        {
            if (lineupIndex < 0)
            {
                return;
            }
            LineupData.Lineups.TryGetValue(lineupIndex, out LineupInfo? lineup);
            if (lineup == null)
            {
                lineup = new()
                {
                    Name = "",
                    LineupType = 0,
                    BaseAvatars = [new() { BaseAvatarId = avatarId }],
                    LineupData = LineupData,
                    AvatarData = Player.AvatarManager!.AvatarData,
                };
                LineupData.Lineups.Add(lineupIndex, lineup);
            } else
            {
                lineup.BaseAvatars?.Add(new() { BaseAvatarId = avatarId });
                LineupData.Lineups[lineupIndex] = lineup;
            }
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
            if (sendPacket)
            {
                if (lineupIndex == LineupData.CurLineup)
                {
                    Player.SceneInstance?.SyncLineup();
                }
                Player.SendPacket(new PacketSyncLineupNotify(lineup));
            }
        }

        public void AddAvatarToCurTeam(int avatarId, bool sendPacket = true)
        {
            AddAvatar(LineupData.CurLineup, avatarId, sendPacket);
        }

        public void AddSpecialAvatarToCurTeam(int specialAvatarId, bool sendPacket = true)
        {
            LineupData.Lineups.TryGetValue(LineupData.CurLineup, out LineupInfo? lineup);
            GameData.SpecialAvatarData.TryGetValue(specialAvatarId, out var specialAvatar);
            if (specialAvatar == null)
            {
                return;
            }
            if (lineup == null)
            {
                lineup = new()
                {
                    Name = "",
                    LineupType = 0,
                    BaseAvatars = [new() { BaseAvatarId = specialAvatar.AvatarID, SpecialAvatarId = specialAvatarId }],
                    LineupData = LineupData,
                    AvatarData = Player.AvatarManager!.AvatarData,
                };
                LineupData.Lineups.Add(LineupData.CurLineup, lineup);
            } else
            {
                lineup.BaseAvatars?.Add(new() { BaseAvatarId = specialAvatar.AvatarID, SpecialAvatarId = specialAvatarId });
                LineupData.Lineups[LineupData.CurLineup] = lineup;
            }
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
            if (sendPacket)
            {
                Player.SceneInstance?.SyncLineup();
                Player.SendPacket(new PacketSyncLineupNotify(lineup));
            }
        }

        public void RemoveAvatar(int lineupIndex, int avatarId)
        {
            if (lineupIndex < 0)
            {
                return;
            }
            LineupData.Lineups.TryGetValue(lineupIndex, out LineupInfo? lineup);
            if (lineup == null)
            {
                return;
            }
            lineup.BaseAvatars?.RemoveAll(avatar => avatar.BaseAvatarId == avatarId);
            LineupData.Lineups[lineupIndex] = lineup;
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
            if (lineupIndex == LineupData.CurLineup)
            {
                Player.SceneInstance?.SyncLineup();
            }
            Player.SendPacket(new PacketSyncLineupNotify(lineup));
        }

        public void RemoveAvatarFromCurTeam(int avatarId)
        {
            RemoveAvatar(LineupData.CurLineup, avatarId);
        }

        public void RemoveSpecialAvatarFromCurTeam(int specialAvatarId)
        {
            LineupData.Lineups.TryGetValue(LineupData.CurLineup, out LineupInfo? lineup);
            if (lineup == null)
            {
                return;
            }
            lineup.BaseAvatars?.RemoveAll(avatar => avatar.SpecialAvatarId == specialAvatarId);
            LineupData.Lineups[LineupData.CurLineup] = lineup;
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
            Player.SceneInstance?.SyncLineup();
            Player.SendPacket(new PacketSyncLineupNotify(lineup));
        }

        public void ReplaceLineup(Proto.ReplaceLineupCsReq req)
        {
            if (req.Index < 0 || !LineupData.Lineups.ContainsKey((int)req.Index))
            {
                return;
            }
            var lineup = LineupData.Lineups[(int)(req.Index)];
            lineup.BaseAvatars = [];
            foreach (var avatar in req.LineupSlotList)
            {
                AddAvatar((int)req.Index, (int)avatar.Id, false);
            }
            DatabaseHelper.Instance?.UpdateInstance(LineupData);
            if (req.Index == LineupData.CurLineup)
            {
                Player.SceneInstance?.SyncLineup();
            }
            Player.SendPacket(new PacketSyncLineupNotify(lineup));
        }

        public List<AvatarSceneInfo> GetAvatarsFromTeam(int index)
        {
            var lineup = GetLineup(index);
            if (lineup == null)
            {
                return [];
            }

            var avatarList = new List<AvatarSceneInfo>();
            foreach (var avatar in lineup.BaseAvatars!)
            {
                Proto.AvatarType avatarType = Proto.AvatarType.AvatarFormalType;
                Database.Avatar.AvatarInfo? avatarInfo = null;
                if (avatar.SpecialAvatarId > 0)
                {
                    GameData.SpecialAvatarData.TryGetValue(avatar.SpecialAvatarId, out var specialAvatar);
                    if (specialAvatar == null) continue;
                    avatarType = Proto.AvatarType.AvatarTrialType;
                    avatarInfo = specialAvatar.ToAvatarData(Player.Uid);
                } else if (avatar.AssistUid > 0)
                {
                    var avatarStorage = DatabaseHelper.Instance?.GetInstance<Database.Avatar.AvatarData>(avatar.AssistUid);
                    avatarType = Proto.AvatarType.AvatarAssistType;
                    if (avatarStorage == null) continue;
                    foreach (var avatarData in avatarStorage.Avatars!)
                    {
                        if (avatarData.AvatarId == avatar.BaseAvatarId)
                        {
                            avatarInfo = avatarData;
                            break;
                        }
                    }
                } else
                {
                    avatarInfo = Player.AvatarManager!.GetAvatar(avatar.BaseAvatarId);
                }
                if (avatarInfo == null) continue;
                avatarList.Add(new AvatarSceneInfo(avatarInfo, avatarType));
            }

            return avatarList;
        }

        public List<AvatarSceneInfo> GetAvatarsFromCurTeam()
        {
            return GetAvatarsFromTeam(LineupData.CurLineup);
        }
    }
}
