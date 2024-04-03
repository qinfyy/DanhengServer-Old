using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Battle.Skill
{
    public interface IMazeSkillAction
    {
        public void OnEnterBattle(BattleInstance instance);

        public void OnCast();
    }
}
