using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Send.ChessRogue
{
    public class PacketGetChessRogueNousStoryInfoScRsp : BasePacket
    {
        public PacketGetChessRogueNousStoryInfoScRsp() : base(CmdIds.GetChessRogueNousStoryInfoScRsp)
        {
            var proto = new GetChessRogueNousStoryInfoScRsp();

            foreach (var item in GameData.RogueNousMainStoryData.Values)
            {
                proto.MainStoryList.Add(new ChessRogueNousMainStoryInfo
                {
                    MainStoryId = (uint)item.StoryID,
                    Status = ChessRogueNousStoryStatus.ChessRogueNousMainStoryStatusFinish
                });
            }

            foreach (var item in GameData.RogueNousSubStoryData.Values)
            {
                proto.SubStoryList.Add(new ChessRogueNousSubStoryInfo
                {
                    SubStoryId = (uint)item.StoryID,
                });
            }

            SetData(proto);
        }
    }
}
