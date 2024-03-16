using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Game.Avatar
{
    public class AvatarManager : BasePlayerManager
    {
        public AvatarData? AvatarData { get; private set; }

        public AvatarManager(PlayerInstance player) : base(player) 
        {
            var avatars = DatabaseHelper.Instance?.GetInstance<AvatarData>(player.Uid);
            if (avatars == null)
            {
                AvatarData = new()
                {
                    Uid = player.Uid,
                    Avatars = [],
                };
                DatabaseHelper.Instance?.SaveInstance(AvatarData);
            }
            else
            {
                AvatarData = avatars;
                foreach (var avatar in AvatarData?.Avatars ?? [])
                {
                    avatar.PlayerData = player.Data;
                    avatar.Excel = GameData.AvatarConfigData[avatar.AvatarId];
                }
            }
        }

        public void AddAvatar(int avatarId)
        {
            GameData.AvatarConfigData.TryGetValue(avatarId, out AvatarConfigExcel? avatarExcel);
            if (avatarExcel == null)
            {
                return;
            }

            var avatar = new AvatarInfo(avatarExcel)
            {
                AvatarId = avatarId,
                Level = 1,
                Timestamp = DateTime.Now.Ticks / TimeSpan.TicksPerSecond,
                CurrentHp = 10000,
                CurrentSp = 0
            };

            if (avatarId >= 8001)
            {
                avatar.HeroId = 8001;
            }

            if (AvatarData?.Avatars == null)
            {
                AvatarData!.Avatars = [];
            }

            AvatarData.Avatars.Add(avatar);
            DatabaseHelper.Instance?.UpdateInstance(AvatarData);
        }

        public AvatarInfo? GetAvatar(int baseAvatarId)
        {
            if (baseAvatarId > 8000) baseAvatarId = 1005;
            return AvatarData?.Avatars?.Find(avatar => avatar.AvatarId == baseAvatarId);
        }
    }
}
