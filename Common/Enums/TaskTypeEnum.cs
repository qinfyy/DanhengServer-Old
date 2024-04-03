using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Enums
{
    public enum TaskTypeEnum
    {
        None = 0,
        AddMazeBuff = 1,
        RemoveMazeBuff = 2,
        AdventureModifyTeamPlayerHP = 3,
        AdventureModifyTeamPlayerSP = 4,
        CreateSummonUnit = 5,
        AdventureSetAttackTargetMonsterDie = 6,
        AdventureTriggerAttack = 7,
        AdventureFireProjectile = 8,
    }
}
