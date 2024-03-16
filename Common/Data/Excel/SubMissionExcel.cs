namespace EggLink.DanhengServer.Data.Excel
{
    [ResourceEntity("SubMission.json")]
    public class SubMissionExcel : ExcelResource
    {
        public int SubMissionID { get; set; }

        public override int GetId()
        {
            return SubMissionID;
        }

        public override void Loaded()
        {
            GameData.SubMissionData[GetId()] = this;
        }
    }
}
