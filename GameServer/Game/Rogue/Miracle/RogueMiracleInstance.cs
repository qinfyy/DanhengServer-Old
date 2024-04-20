using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Rogue.Miracle
{
    public class RogueMiracleInstance(RogueInstance instance)
    {
        public RogueInstance Instance { get; } = instance;
        public int MiracleId { get; private set; }
        public int Durability { get; private set; }
        public int UsedTimes { get; set; }
        public bool IsDestroyed { get; set; } = false;

        public void OnStartBattle(BattleInstance battle)
        {
            if (IsDestroyed) return;
        }

        public void OnEndBattle(BattleInstance battle)
        {
            if (IsDestroyed) return;
        }

        public void OnEnterNextRoom()
        {
            if (IsDestroyed) return;
        }

        public void OnGetMiracle()
        {
            if (IsDestroyed) return;
        }

        public void OnDestroy()
        {
            if (IsDestroyed) return;
        }

        public void CostDurability(int value)
        {
            UsedTimes = Math.Min(UsedTimes + value, Durability);  // Prevent overflow
            if (Durability > 0)  // 0 means infinite durability
            {
                if (Durability <= UsedTimes)  // Destroy the miracle
                {
                    OnDestroy();
                    IsDestroyed = true;
                }
            }
        }

        public RogueMiracle ToProto()  // TODO: Implement
        {
            return new()
            {
                MiracleId = (uint)MiracleId,
                Durability = (uint)Durability,
                UsedTimes = (uint)UsedTimes
            };
        }
    }
}
