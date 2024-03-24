using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Tutorial;

namespace EggLink.DanhengServer.Server.Packet.Recv.Tutorial
{
    [Opcode(CmdIds.FinishTutorialCsReq)]
    public class HandlerFinishTutorialCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = FinishTutorialCsReq.Parser.ParseFrom(data);
            var player = connection.Player!;
            if (player.TutorialData!.Tutorials.TryGetValue((int)req.TutorialId, out var res))
            {
                if (res != TutorialStatus.TutorialFinish)
                {
                    player.InventoryManager!.AddItem(1, 1);
                    player.TutorialData!.Tutorials[(int)req.TutorialId] = TutorialStatus.TutorialFinish;
                }
            }

            connection.SendPacket(new PacketFinishTutorialScRsp(req.TutorialId));
        }
    }
}
