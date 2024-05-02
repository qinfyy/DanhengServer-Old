using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Friend;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Friend
{
    public class FriendManager(PlayerInstance player) : BasePlayerManager(player)
    {
        public FriendData FriendData { get; set; } = DatabaseHelper.Instance!.GetInstanceOrCreateNew<FriendData>(player.Uid);

        public void AddFriend()
        {
        }

        public void RemoveFriend()
        {
        }

        public List<PlayerData> GetFriendList()
        {
            List<PlayerData> list = [];

            foreach (var friend in FriendData.FriendList)
            {
                var player = PlayerData.GetPlayerByUid(friend);

                if (player != null)
                {
                    list.Add(player);
                }
            }

            return list;
        }

        public List<PlayerData> GetBlackList()
        {
            List<PlayerData> list = [];

            foreach (var friend in FriendData.BlackList)
            {
                var player = PlayerData.GetPlayerByUid(friend);

                if (player != null)
                {
                    list.Add(player);
                }
            }

            return list;
        }

        public List<PlayerData> GetSendApplyList()
        {
            List<PlayerData> list = [];

            foreach (var friend in FriendData.SendApplyList)
            {
                var player = PlayerData.GetPlayerByUid(friend);

                if (player != null)
                {
                    list.Add(player);
                }
            }

            return list;
        }

        public List<PlayerData> GetReceiveApplyList()
        {
            List<PlayerData> list = [];

            foreach (var friend in FriendData.ReceiveApplyList)
            {
                var player = PlayerData.GetPlayerByUid(friend);

                if (player != null)
                {
                    list.Add(player);
                }
            }

            return list;
        }

        public GetFriendListInfoScRsp ToProto()
        {
            var proto = new GetFriendListInfoScRsp();

            var serverProfile = ConfigManager.Config.ServerOption.ServerProfile;

            proto.FriendList.Add(new FriendSimpleInfo()
            {
                PlayerInfo = new PlayerSimpleInfo()
                {
                    Uid = (uint)serverProfile.Uid, // TODO: UID is always 0 now
                    HeadIcon = (uint)serverProfile.HeadIcon,
                    IsBanned = false,
                    Level = (uint)serverProfile.Level,
                    Nickname = serverProfile.Name,
                    OnlineStatus = FriendOnlineStatus.Online,
                    Platform = PlatformType.Pc,
                    Signature = "DanhengServer command executor",
                },
                IsRemarked = false, // IsMarked
                RemarkName = ""
            });

            foreach (var player in GetFriendList())
            {
                proto.FriendList.Add(new FriendSimpleInfo()
                {
                    PlayerInfo = player.ToSimpleProto(),
                    IsRemarked = false, // IsMarked
                    RemarkName = ""
                });
            }

            foreach (var player in GetBlackList())
            {
                proto.BlackList.Add(player.ToSimpleProto());
            }

            return proto;
        }

        public GetFriendApplyListInfoScRsp ToApplyListProto()
        {
            GetFriendApplyListInfoScRsp proto = new GetFriendApplyListInfoScRsp();

            foreach (var player in GetSendApplyList())
            {
                proto.SendApplyList.Add((uint)player.Uid);
            }

            foreach (var player in GetReceiveApplyList())
            {
                proto.ReceiveApplyList.Add(new FriendApplyInfo()
                {
                    PlayerInfo = player.ToSimpleProto()
                });
            }

            return proto;
        }
    }
}
