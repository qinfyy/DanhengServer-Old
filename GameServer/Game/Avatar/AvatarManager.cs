using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Avatar
{
    public class AvatarManager : BasePlayerManager
    {
        public AvatarData AvatarData { get; private set; }

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

            if (AvatarData.Avatars == null)
            {
                AvatarData.Avatars = [];
            }

            AvatarData.Avatars.Add(avatar);
            DatabaseHelper.Instance?.UpdateInstance(AvatarData);
        }
    }
}
