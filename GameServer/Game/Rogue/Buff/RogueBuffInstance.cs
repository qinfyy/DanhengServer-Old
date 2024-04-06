using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Rogue.Buff
{
    public class RogueBuffInstance(int buffId, int buffLevel)
    {
        public int BuffId { get; set; } = buffId;
        public int BuffLevel { get; set; } = buffLevel;

        public RogueBuff ToProto() => new()
        {
            BuffId = (uint)BuffId,
            Level = (uint)BuffLevel
        };
    }
}
