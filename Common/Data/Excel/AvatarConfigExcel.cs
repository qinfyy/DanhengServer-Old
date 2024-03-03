namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("AvatarConfig.json", true)]
    public class AvatarConfigExcel : ExcelResource
    {
        public int AvatarID { get; set; } = 0;
        public HashName AvatarName { get; set; } = new();

        public List<AvatarSkillTreeConfigExcel> DefaultSkillTree = [];
        public override int GetId()
        {
            return AvatarID;
        }

        public override void Loaded()
        {
            GameData.AvatarConfigData.Add(AvatarID, this);
        }
    }
}
