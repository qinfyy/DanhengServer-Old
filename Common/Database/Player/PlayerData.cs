using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Player
{
    [SugarTable("Player")]
    public class PlayerData : BaseDatabaseData
    {
        public string? Name { get; set; }
        public string? Signature { get; set; }
        public int Birthday { get; set; }
        public int CurBasicType { get; set; }
        public int HeadIcon { get; set; }
        public int PhoneTheme { get; set; }
        public int ChatBubble { get; set; }
        public int CurrentBgm { get; set; }
        public Gender? CurrentGender { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int WorldLevel { get; set; }
        public int Scoin { get; set; } // Credits
        public int Hcoin { get; set; } // Jade
        public int Mcoin { get; set; } // Crystals
        public int TalentPoints { get; set; } // Rogue talent points

        public int Stamina { get; set; }
        public double StaminaReserve { get; set; }
        public long NextStaminaRecover { get; set; }

        [SugarColumn(IsNullable = true, IsJson = true)]
        public Position? Pos { get; set; }
        [SugarColumn(IsNullable = true, IsJson = true)]
        public Position? Rot { get; set; }
        [SugarColumn(IsNullable = true)]
        public int PlaneId { get; set; }
        [SugarColumn(IsNullable = true)]
        public int FloorId { get; set; }
        [SugarColumn(IsNullable = true)]
        public int EntryId { get; set; }

        [SugarColumn(IsNullable = true)]
        public long LastActiveTime { get; set; }


    }
}
