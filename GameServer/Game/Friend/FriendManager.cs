using EggLink.DanhengServer.Database.Friend;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Game.Friend
{
    public class FriendManager(PlayerInstance player) : BasePlayerManager(player)
    {
        public FriendData FriendData { get; set; } = new();
        // TODO: add friend and remove friend
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
            var proto = new GetFriendListInfoScRsp()
            {
                Retcode = 0
            };
            
            proto.FriendList.Add(new FriendSimpleInfo()
            {
                PlayerInfo = new PlayerSimpleInfo()
                {
                    Uid = 7121310, // TODO: UID is always 0 now
                    HeadIcon = 201002,
                    IsBanned = false,
                    Level = 70,
                    Nickname = "Server",
                    OnlineStatus = FriendOnlineStatus.Online,
                    Platform = PlatformType.Pc,
                    Signature = "DanhengServer command executor",
                },
                OBOJFJPCEHE = false, // IsMarked
                RemarkName = ""
            });

            foreach (var player in GetFriendList())
            {
                proto.FriendList.Add(new FriendSimpleInfo()
                {
                    PlayerInfo = new PlayerSimpleInfo()
                    {
                        HeadIcon = (uint)player.HeadIcon,
                        Level = (uint)player.Level,
                        Nickname = player.Name,
                        Uid = (uint)player.Uid,
                        Signature = player.Signature,
                        IsBanned = false
                    },
                    OBOJFJPCEHE = false, // IsMarked
                    RemarkName = ""
                });
            }

            foreach (var player in GetBlackList())
            {
                proto.BlackList.Add(new PlayerSimpleInfo()
                {
                    HeadIcon = (uint)player.HeadIcon,
                    Level = (uint)player.Level,
                    Nickname = player.Name,
                    Uid = (uint)player.Uid,
                    Signature = player.Signature,
                    IsBanned = false
                });
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
                    PlayerInfo = new PlayerSimpleInfo()
                    {
                        HeadIcon = (uint)player.HeadIcon,
                        Level = (uint)player.Level,
                        Nickname = player.Name,
                        Uid = (uint)player.Uid,
                        Signature = player.Signature,
                        IsBanned = false
                    }
                });
            }

            return proto;
        }
    }
}
