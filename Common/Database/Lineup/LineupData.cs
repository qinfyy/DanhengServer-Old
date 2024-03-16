using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Proto;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Database.Lineup
{
    [SugarTable("Lineup")]
    public class LineupData : BaseDatabaseData
    {
        public int CurLineup { get; set; }  // index of current lineup
        [SugarColumn(IsJson = true)]
        public Dictionary<int, LineupInfo> Lineups { get; set; } = [];  // 9 * 4
        public int Mp { get; set; } = 5;
    }

    public class LineupInfo
    {
        public string? Name { get; set; }
        public int LineupType { get; set; }
        public int LeaderAvatarId { get; set; }
        public List<AvatarInfo>? BaseAvatars { get; set; }

        [JsonIgnore()]
        public LineupData? LineupData { get; set; }

        [JsonIgnore()]
        public AvatarData? AvatarData { get; set; }

        public int GetSlot(int avatarId)
        {
            return BaseAvatars?.FindIndex(item => item.BaseAvatarId == avatarId) ?? -1;
        }

        public bool Heal(int count, bool allowRevive)
        {
            bool result = false;
            if (BaseAvatars != null && AvatarData != null)
            {
                foreach (var avatar in BaseAvatars)
                {
                    var avatarInfo = AvatarData?.Avatars?.Find(item => item.GetAvatarId() == avatar.BaseAvatarId);
                    if (avatarInfo != null)
                    {
                        if (avatarInfo.CurrentHp <= 0 && !allowRevive)
                        {
                            continue;
                        }
                        if (avatarInfo.CurrentHp >= 10000)
                        {
                            continue;
                        }
                        avatarInfo.CurrentHp = Math.Min(avatarInfo.GetCurHp(LineupType != 0) + count, 10000);
                        result = true;
                    }
                }
                DatabaseHelper.Instance?.UpdateInstance(AvatarData!);
            }
            return result;
        }

        public bool IsExtraLineup()
        {
            return LineupType != 0;
        }

        public Proto.LineupInfo ToProto()
        {
            Proto.LineupInfo info = new()
            {
                Name = Name,
                MaxMp = 5,
                Mp = (uint)(LineupData?.Mp ?? 0),
                ExtraLineupType = ExtraLineupType.LineupNone,
                Index = (uint)(LineupData?.Lineups?.Values.ToList().IndexOf(this) ?? 0),
            };
            if (BaseAvatars?.Find(item => item.BaseAvatarId == LeaderAvatarId) != null)
            {
                info.LeaderSlot = (uint)BaseAvatars.IndexOf(BaseAvatars.Find(item => item.BaseAvatarId == LeaderAvatarId)!);
            } else
            {
                info.LeaderSlot = 0;
            }
            if (BaseAvatars != null)
            {
                foreach (var avatar in BaseAvatars)
                {
                    if (avatar.AssistUid != 0)
                    {
                        var assistPlayer = DatabaseHelper.Instance?.GetInstance<AvatarData>(avatar.AssistUid);
                        if (assistPlayer != null)
                        {
                            info.AvatarList.Add(assistPlayer?.Avatars?.Find(item => item.GetAvatarId() == avatar.BaseAvatarId)?.ToLineupInfo(BaseAvatars.IndexOf(avatar), this, Proto.AvatarType.AvatarAssistType));
                        }
                    } else if (avatar.SpecialAvatarId != 0)
                    {
                        var specialAvatar = GameData.SpecialAvatarData[avatar.SpecialAvatarId];
                        if (specialAvatar != null)
                        {
                            info.AvatarList.Add(specialAvatar.ToAvatarData().ToLineupInfo(BaseAvatars.IndexOf(avatar), this, AvatarType.AvatarTrialType));
                        }
                    } else
                    {
                        info.AvatarList.Add(AvatarData?.Avatars?.Find(item => item.AvatarId == avatar.BaseAvatarId)?.ToLineupInfo(BaseAvatars.IndexOf(avatar), this));
                    }
                }
            }

            return info;
        }
    }

    public class AvatarInfo
    {
        public int BaseAvatarId { get; set; }
        public int AssistUid { get; set; }
        public int SpecialAvatarId { get; set; }
    }
}
