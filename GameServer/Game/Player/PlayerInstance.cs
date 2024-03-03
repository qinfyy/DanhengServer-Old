using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Avatar;
using EggLink.DanhengServer.Game.Inventory;
using EggLink.DanhengServer.Game.Lineup;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server;
using EggLink.DanhengServer.Server.Packet;
using EggLink.DanhengServer.Server.Packet.Send.Player;

namespace EggLink.DanhengServer.Game.Player
{
    public class PlayerInstance(PlayerData data)
    {
        public PlayerData Data { get; set; } = data;
        public ushort Uid { get; set; }
        public Connection? Connection { get; set; }
        public bool Initialized { get; set; } = false;

        #region Managers

        public AvatarManager AvatarManager { get; private set; }
        public LineupManager LineupManager { get; private set; }
        public InventoryManager InventoryManager { get; private set; }

        #endregion

        #region Datas

        public PlayerUnlockData PlayerUnlockData { get; private set; }
        public SceneInstance SceneInstance { get; private set; }

        #endregion

        public PlayerInstance() : this(new PlayerData())
        {
            // new player
            Data.Name = "无名客"; // Trailblazer in EN  TODO: Add localization
            Data.Signature = ""; 
            Data.Birthday = 0;
            Data.CurBasicType = 8001;
            Data.HeadIcon = 208001;
            Data.PhoneTheme = 221000;
            Data.ChatBubble = 220000;
            Data.CurrentBgm = 210000;
            Data.CurrentGender = Gender.Man;
            Data.Stamina = 240;
            Data.StaminaReserve = 0;
            Data.NextStaminaRecover = DateTime.Now.Millisecond;
            Data.Level = 1;
            Data.Exp = 0;
            Data.WorldLevel = 0;
            Data.Scoin = 0;
            Data.Hcoin = 0;
            Data.Mcoin = 0;
            Data.TalentPoints = 0;

            InitialPlayerManager();

            AddAvatar(1005);
            LineupManager.SetCurLineup(0);
            LineupManager.AddAvatarToCurTeam(1005);
            Initialized = true;
        }

        private void InitialPlayerManager()
        {
            Uid = (ushort)Data.Uid;
            AvatarManager = new(this);
            LineupManager = new(this);
            InventoryManager = new(this);

            var unlock = DatabaseHelper.Instance?.GetInstance<PlayerUnlockData>(Uid);
            if (unlock == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new PlayerUnlockData()
                {
                    Uid = Uid,
                });
                unlock = DatabaseHelper.Instance?.GetInstance<PlayerUnlockData>(Uid);
            }
            PlayerUnlockData = unlock!;
            SceneInstance = new(this, GameData.MazePlaneData[20001], 20001001);
        }



        #region Network
        public void OnLogin()
        {
            if (!Initialized)
            {
                InitialPlayerManager();
            }
            
            SendPacket(new PacketStaminaInfoScNotify(this));

        }

        public async Task OnLogoutAsync()
        {

        }

        public void SendPacket(BasePacket packet)
        {
            Connection?.SendPacket(packet);
        }
        #endregion

        #region Extra

        public void AddAvatar(int avatarId)
        {
            AvatarManager.AddAvatar(avatarId);
        }

        #endregion

        #region Proto

        public PlayerBasicInfo ToProto()
        {
            return new()
            {
                Nickname = Data.Name,
                Level = (uint)Data.Level,
                Exp = (uint)Data.Exp,
                WorldLevel = (uint)Data.WorldLevel,
                Scoin = (uint)Data.Scoin,
                Hcoin = (uint)Data.Hcoin,
                Mcoin = (uint)Data.Mcoin,
                Stamina = (uint)Data.Stamina,
            };
        }

        #endregion
    }
}
