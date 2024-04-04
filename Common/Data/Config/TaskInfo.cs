using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Data.Config
{
    public class TaskInfo
    {
        public string Type { get; set; } = "";

        public int ID { get; set; }
        public int SummonUnitID { get; set; }

        public bool TriggerBattle { get; set; } = true;

        public List<TaskInfo> OnAttack { get; set; } = [];
        public List<TaskInfo> OnBattle { get; set; } = [];
        public List<TaskInfo> SuccessTaskList { get; set; } = [];
        public List<TaskInfo> OnProjectileHit { get; set; } = [];
        public List<TaskInfo> OnProjectileLifetimeFinish { get; set; } = [];

        [JsonIgnore]
        public TaskTypeEnum TaskType { get; set; } = TaskTypeEnum.None;

        public void Loaded()
        {
            foreach (var task in OnAttack)
            {
                task.Loaded();
            }
            foreach (var task in OnBattle)
            {
                task.Loaded();
            }
            foreach (var task in SuccessTaskList)
            {
                task.Loaded();
            }
            foreach (var task in OnProjectileHit)
            {
                task.Loaded();
            }
            foreach (var task in OnProjectileLifetimeFinish)
            {
                task.Loaded();
            }
            if (Type.Contains("AddMazeBuff"))
            {
                TaskType = TaskTypeEnum.AddMazeBuff;
            } else if (Type.Contains("RemoveMazeBuff"))
            {
                TaskType = TaskTypeEnum.RemoveMazeBuff;
            } else if (Type.Contains("AdventureModifyTeamPlayerHP"))
            {
                TaskType = TaskTypeEnum.AdventureModifyTeamPlayerHP;
            } else if (Type.Contains("AdventureModifyTeamPlayerSP"))
            {
                TaskType = TaskTypeEnum.AdventureModifyTeamPlayerSP;
            } else if (Type.Contains("CreateSummonUnit"))
            {
                TaskType = TaskTypeEnum.CreateSummonUnit;
            } else if (Type.Contains("AdventureSetAttackTargetMonsterDie"))
            {
                TaskType = TaskTypeEnum.AdventureSetAttackTargetMonsterDie;
            } else if (SuccessTaskList.Count > 0)
            {
                TaskType = TaskTypeEnum.SuccessTaskList;
            }
            else if (Type.Contains("AdventureTriggerAttack"))
            {
                TaskType = TaskTypeEnum.AdventureTriggerAttack;
            } else if (Type.Contains("AdventureFireProjectile"))
            {
                TaskType = TaskTypeEnum.AdventureFireProjectile;
            }
        }

        public int GetID()
        {
            return ID > 0 ? ID : SummonUnitID;
        }

        public List<TaskInfo> GetAttackInfo()
        {
            var attackInfo = new List<TaskInfo>();
            attackInfo.AddRange(OnAttack);
            attackInfo.AddRange(OnBattle);
            return attackInfo;
        }
    }
}
