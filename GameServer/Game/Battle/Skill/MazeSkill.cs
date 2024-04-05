using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Game.Battle.Skill.Action;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Game.Scene.Entity;
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
        public bool IsMazeSkill { get; private set; } = true;
        public AvatarConfigExcel? Excel { get; private set; }

        public MazeSkill(List<TaskInfo> taskInfos, bool isSkill = false, AvatarConfigExcel? excel = null)
        {
            foreach (var task in taskInfos)
            {
                AddAction(task);
            }
            IsMazeSkill = isSkill;
            Excel = excel;
        }

        public void AddAction(TaskInfo task)
        {
            switch (task.TaskType)
            {
                case Enums.TaskTypeEnum.None:
                    break;
                case Enums.TaskTypeEnum.AddMazeBuff:
                    Actions.Add(new MazeAddMazeBuff(task.ID, task.LifeTime.GetLifeTime()));
                    break;
                case Enums.TaskTypeEnum.RemoveMazeBuff:
                    Actions.RemoveAll(a => a is MazeAddMazeBuff buff && buff.BuffId == task.ID);
                    break;
                case Enums.TaskTypeEnum.AdventureModifyTeamPlayerHP:
                    break;
                case Enums.TaskTypeEnum.AdventureModifyTeamPlayerSP:
                    break;
                case Enums.TaskTypeEnum.CreateSummonUnit:
                    break;
                case Enums.TaskTypeEnum.AdventureSetAttackTargetMonsterDie:
                    Actions.Add(new MazeSetTargetMonsterDie());
                    break;
                case Enums.TaskTypeEnum.SuccessTaskList:
                    foreach (var t in task.SuccessTaskList)
                    {
                        AddAction(t);
                    }
                    break;
                case Enums.TaskTypeEnum.AdventureTriggerAttack:
                    if (IsMazeSkill)
                    {
                        TriggerBattle = task.TriggerBattle;
                    }

                    foreach (var t in task.GetAttackInfo())
                    {
                        AddAction(t);
                    }
                    break;
                case Enums.TaskTypeEnum.AdventureFireProjectile:
                    foreach (var t in task.OnProjectileHit)
                    {
                        AddAction(t);
                    }

                    foreach (var t in task.OnProjectileLifetimeFinish)
                    {
                        AddAction(t);
                    }
                    break;
            }
        }

        public void OnCast(AvatarSceneInfo info)
        {
            foreach (var action in Actions)
            {
                action.OnCast(info);
            }
        }

        public void OnAttack(AvatarSceneInfo info, List<EntityMonster> entities)
        {
            foreach (var action in Actions)
            {
                action.OnAttack(info, entities);
            }
        }

        public void OnHitTarget(AvatarSceneInfo info, List<EntityMonster> entities)
        {
            foreach (var action in Actions)
            {
                action.OnHitTarget(info, entities);
            }
        }
    }
}
