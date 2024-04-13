using EggLink.DanhengServer.Game.Battle;
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

        public void OnStartBattle(BattleInstance battle)
        {
            battle.Buffs.Add(new(BuffId, BuffLevel, -1)
            {
                WaveFlag = -1
            });
        }

        public RogueBuff ToProto() => new()
        {
            BuffId = (uint)BuffId,
            Level = (uint)BuffLevel
        };

        public RogueCommonActionResult ToResultProto(RogueActionSource source) => new()
        {
            RogueAction = new()
            {
                GetBuffList = new()
                {
                    BuffId = (uint)BuffId,
                    BuffLevel = (uint)BuffLevel
                }
            },
            Source = source
        };
    }
}
