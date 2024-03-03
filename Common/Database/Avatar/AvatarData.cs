using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Proto;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Avatar
{
    [SugarTable("Avatar")]
    public class AvatarData : BaseDatabaseData
    {
        [SugarColumn(IsNullable = true)]
        public List<AvatarInfo>? Avatars { get; set; }

        public List<int> AssistAvatars { get; set; } = [];
        public List<int> DisplayAvatars { get; set; } = [];
    }

    public class AvatarInfo
    {
        public int AvatarId { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Promotion { get; set; }
        public int Rewards { get; set; }
        public long Timestamp { get; set; }
        public int CurrentHp { get; set; }
        public int CurrentSp { get; set; }
        public int ExtraLineupHp { get; set; }
        public int ExtraLineupSp { get; set; }
        public int Rank { get; set; }
        public Dictionary<int, int> SkillTree { get; set; } = [];
        public int EquipId { get; set; } = 0;
        public Dictionary<int, int> Relic { get; set; } = [];

        public AvatarConfigExcel Excel;

        public AvatarInfo(AvatarConfigExcel excel)
        {
            Excel = excel;
            SkillTree = [];
            excel.DefaultSkillTree.ForEach(skill =>
            {
                SkillTree.Add(skill.PointID, skill.Level);
            });
        }

        public bool HasTakenReward(int promotion)
        {
            return (Rewards & (1 << promotion)) != 0;
        }

        public Proto.Avatar ToProto()
        {
            var proto = new Proto.Avatar()
            {
                BaseAvatarId = (uint)AvatarId,
                Level = (uint)Level,
                Exp = (uint)Exp,
                Promotion = (uint)Promotion,
                Rank = (uint)Rank,
                FirstMetTimestamp = (ulong)Timestamp,
            };

            foreach (var item in Relic)
            {
                proto.EquipRelicList.Add(new EquipRelic()
                {
                    RelicUniqueId = (uint)item.Value,
                    Slot = (uint)item.Key
                });
            }

            if (EquipId != 0)
            {
                proto.EquipmentUniqueId = (uint)EquipId;
            }

            foreach (var skill in SkillTree)
            {
                proto.SkilltreeList.Add(new AvatarSkillTree()
                {
                    PointId = (uint)skill.Key,
                    Level = (uint)skill.Value
                });
            }

            for (int i = 0; i < Promotion; i++)
            {
                if (HasTakenReward(i))
                {
                    proto.TakenRewards.Add((uint)i);
                }
            }

            return proto;
        }
    }
}
