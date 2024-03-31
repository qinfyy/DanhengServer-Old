using EggLink.DanhengServer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("AvatarConfig.json", true)]
    public class AvatarConfigExcel : ExcelResource
    {
        public int AvatarID { get; set; } = 0;
        public HashName AvatarName { get; set; } = new();
        public int ExpGroup { get; set; } = 0;
        public List<int> RankIDList { get; set; } = [];

        [JsonConverter(typeof(StringEnumConverter))]
        public RarityEnum Rarity { get; set; } = 0;

        [JsonIgnore()]
        public List<AvatarSkillTreeConfigExcel> DefaultSkillTree = [];

        [JsonIgnore()]
        public int RankUpItemId { get; set; }

        public override int GetId()
        {
            return AvatarID;
        }

        public override void Loaded()
        {
            GameData.AvatarConfigData.Add(AvatarID, this);
            RankUpItemId = AvatarID + 10000;
        }
    }
}
