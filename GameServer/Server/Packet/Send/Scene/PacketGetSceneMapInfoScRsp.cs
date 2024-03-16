using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Server.Packet.Send.Scene
{
    public class PacketGetSceneMapInfoScRsp : BasePacket
    {
        public PacketGetSceneMapInfoScRsp(GetSceneMapInfoCsReq req, PlayerInstance player) : base(CmdIds.GetSceneMapInfoScRsp)
        {
            var rsp = new GetSceneMapInfoScRsp();
            foreach (var entry in req.EntryIdList)
            {
                var mazeMap = new MazeMapData()
                {
                    EntryId = entry,
                };
                GameData.MapEntranceData.TryGetValue((int)entry, out var mapData);
                if (mapData == null)
                {
                    rsp.MapList.Add(mazeMap);
                    continue;
                }

                GameData.GetFloorInfo(mapData.PlaneID, mapData.FloorID, out var floorInfo);
                if (floorInfo == null)
                {
                    rsp.MapList.Add(mazeMap);
                    continue;
                }

                mazeMap.UnlockedChestList.Add(new MazeChest()
                {
                    TotalAmountList = 1,
                    MapInfoChestType = MapInfoChestType.Normal
                });

                mazeMap.UnlockedChestList.Add(new MazeChest()
                {
                    TotalAmountList = 1,
                    MapInfoChestType = MapInfoChestType.Puzzle
                });

                mazeMap.UnlockedChestList.Add(new MazeChest()
                {
                    TotalAmountList = 1,
                    MapInfoChestType = MapInfoChestType.Challenge
                });

                foreach (GroupInfo groupInfo in floorInfo.Groups.Values)  // all the icons on the map
                {
                    var mazeGroup = new MazeGroup()
                    {
                        GroupId = (uint)groupInfo.Id,
                    };
                    mazeMap.MazeGroupList.Add(mazeGroup);
                }

                foreach (var teleport in floorInfo.CachedTeleports.Values)
                {
                    mazeMap.UnlockTeleportList.Add((uint)teleport.MappingInfoID);
                }

                foreach (var prop in floorInfo.UnlockedCheckpoints)
                {
                    var mazeProp = new MazeProp()
                    {
                        GroupId = (uint)prop.AnchorGroupID,
                        ConfigId = (uint)prop.ID,
                        State = (uint)PropStateEnum.CheckPointEnable,
                    };
                    mazeMap.MazePropList.Add(mazeProp);
                }

                player.SceneData!.UnlockSectionIdList.TryGetValue(mapData.FloorID, out var sections);
                foreach (var section in sections ?? [])
                {
                    mazeMap.LightenSectionList.Add((uint)section);
                }
                rsp.MapList.Add(mazeMap);
            }
            SetData(rsp);
        }
    }
}
