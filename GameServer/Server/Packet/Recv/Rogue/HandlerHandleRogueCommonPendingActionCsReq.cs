using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using Google.Protobuf;

namespace EggLink.DanhengServer.Server.Packet.Recv.Rogue
{
    [Opcode(CmdIds.HandleRogueCommonPendingActionCsReq)]
    public class HandlerHandleRogueCommonPendingActionCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = HandleRogueCommonPendingActionCsReq.Parser.ParseFrom(data);

            var rogue = connection.Player!.RogueManager?.RogueInstance;
            if (rogue == null) return;

            if (req.BuffSelectResult != null)
            {
                rogue.HandleBuffSelect((int)req.BuffSelectResult.BuffId);
            }

            if (req.BuffRerollSelectResult != null)
            {
                Logger.GetByClassName().Debug("BuffRerollSelectResult");
            }

            if (req.BonusSelectResult != null)
            {
                rogue.HandleBonusSelect((int)req.BonusSelectResult.BonusId);
            }
        }
    }
}
