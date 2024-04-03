using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Scene
{
    public class SceneBuff
    {
        public int BuffID { get; private set; }
        public int BuffLevel { get; private set; }

        public SceneBuff(int buffID, int buffLevel)
        {
            BuffID = buffID;
            BuffLevel = buffLevel;
        }

        public BattleBuff ToProto(int owner, int waveFlag) => new()
        {
            Id = (uint)BuffID,
            Level = (uint)BuffLevel,
            OwnerIndex = (uint)owner,
            WaveFlag = (uint)waveFlag,
            TargetIndexList = { (uint)owner },
        };
    }
}
