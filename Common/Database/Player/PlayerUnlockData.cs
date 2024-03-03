namespace EggLink.DanhengServer.Database.Player
{
    public class PlayerUnlockData : BaseDatabaseData
    {
        public List<int> HeadIcons { get; set; } = [];
        public List<int> ChatBubbles { get; set; } = [];
        public List<int> PhoneThemes { get; set; } = [];
    }
}
