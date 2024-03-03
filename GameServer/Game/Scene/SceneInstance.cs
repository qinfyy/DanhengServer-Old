using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Game.Scene
{
    public class SceneInstance
    {
        public PlayerInstance Player;
        public MazePlaneExcel Excel;
        public FloorInfo FloorInfo;
        public int FloorId;
        public int PlaneId;
        public int EntryId;
        public int LeaveEntryId;

        public int LastEntityId;
        public bool IsLoaded = false;

        public SceneInstance(PlayerInstance player, MazePlaneExcel excel, int floorId)
        {
            Player = player;
            Excel = excel;
            PlaneId = excel.PlaneID;
            FloorId = floorId;
            GameData.GetFloorInfo(PlaneId, FloorId, out FloorInfo);
            if (FloorInfo == null) return;

        }

        public SceneInfo ToProto()
        {
            SceneInfo sceneInfo = new()
            {
                WorldId = (uint)Excel.WorldID,
                GameModeType = (uint)Excel.PlaneType,
                PlaneId = (uint)PlaneId,
                FloorId = (uint)FloorId,
                EntryId = (uint)EntryId,
            };

            return sceneInfo;
        }
    }
}
