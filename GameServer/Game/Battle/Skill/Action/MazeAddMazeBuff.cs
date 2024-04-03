using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Game.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Battle.Skill.Action
{
    public class MazeAddMazeBuff(int buffId) : IMazeSkillAction
    {
        public void OnCast()
        {

        }

        public void OnEnterBattle(BattleInstance instance)
        {
            instance.Buffs.Add(new SceneBuff(buffId, 1));
        }
    }
}
