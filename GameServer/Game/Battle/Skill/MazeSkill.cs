using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Game.Battle.Skill.Action;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Battle.Skill
{
    public class MazeSkill
    {
        public List<IMazeSkillAction> Actions { get; private set; } = [];
        public bool TriggerBattle { get; private set; } = true;
        public MazeSkill(List<TaskInfo> taskInfos)
        {
            foreach (var task in taskInfos)
            {
                AddAction(task);
                foreach (var t in task.SuccessTaskList)
                {
                    AddAction(t);
                }
                foreach (var t in task.GetAttackInfo())
                {
                    AddAction(t);
                }

                foreach (var t in task.OnProjectileHit)
                {
                    AddAction(t);
                }
                foreach (var t in task.OnProjectileLifetimeFinish)
                {
                    AddAction(t);
                }
            }
        }

        public void AddAction(TaskInfo task)
        {
            switch (task.TaskType)
            {
                case Enums.TaskTypeEnum.None:
                    break;
                case Enums.TaskTypeEnum.AddMazeBuff:
                    Actions.Add(new MazeAddMazeBuff(task.ID));
                    break;
                case Enums.TaskTypeEnum.RemoveMazeBuff:
                    break;
                case Enums.TaskTypeEnum.AdventureModifyTeamPlayerHP:
                    break;
                case Enums.TaskTypeEnum.AdventureModifyTeamPlayerSP:
                    break;
                case Enums.TaskTypeEnum.CreateSummonUnit:
                    break;
                case Enums.TaskTypeEnum.AdventureSetAttackTargetMonsterDie:
                    break;
                case Enums.TaskTypeEnum.AdventureTriggerAttack:
                    foreach (var t in task.GetAttackInfo())
                    {
                        AddAction(t);
                    }
                    break;
                case Enums.TaskTypeEnum.AdventureFireProjectile:
                    break;
            }

            if (!task.TriggerBattle)
            {
                TriggerBattle = false;
            }
        }

        public void OnEnterBattle(BattleInstance instance)
        {
            foreach (var action in Actions)
            {
                action.OnEnterBattle(instance);
            }
        }
    }
}
