using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Server.Packet.Recv.Battle
{
    [Opcode(CmdIds.SceneCastSkillCsReq)]
    public class HandlerSceneCastSkillCsReq : Handler
    {
        public override void OnHandle(Connection connection, byte[] header, byte[] data)
        {
            var req = SceneCastSkillCsReq.Parser.ParseFrom(data);
            if (req != null)
            {
                if (req.HitTargetEntityIdList.Count == 0)
                {
                    // didnt hit any target
                    connection.SendPacket(new PacketSceneCastSkillScRsp(req.CastEntityId));
                } else connection.Player!.BattleManager!.StartBattle(req);
            }
        }
    }
}
