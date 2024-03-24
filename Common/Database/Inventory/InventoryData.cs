using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Inventory
{
    public class InventoryData : BaseDatabaseData
    {
        [SugarColumn(IsJson = true)]
        public List<ItemData> MaterialItems { get; set; } = [];
        [SugarColumn(IsJson = true)]
        public List<ItemData> EquipmentItems { get; set; } = [];
        [SugarColumn(IsJson = true)]
        public List<ItemData> RelicItems { get; set; } = [];

        public int NextUniqueId { get; set; } = 100;
    }

    public class ItemData
    {
        public int UniqueId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int TotalExp { get; set; }
        public int Promotion { get; set; }
        public int Rank { get; set; } // Superimpose
        public bool Locked { get; set; }
        public bool Discarded { get; set; }

        public int MainAffix { get; set; }
        public List<ItemSubAffix> SubAffixes { get; set; } = [];

        public int EquipAvatar { get; set; }

        #region Action

        public void AddRandomRelicMainAffix()
        {
            GameData.RelicConfigData.TryGetValue(ItemId, out var config);
            if (config == null) return;
            var affixId = GameTools.GetRandomRelicMainAffix(config.MainAffixGroup);
            MainAffix = affixId;
        }

        public void IncreaseRandomRelicSubAffix()
        {
            GameData.RelicConfigData.TryGetValue(ItemId, out var config);
            if (config == null) return;
            GameData.RelicSubAffixData.TryGetValue(config.SubAffixGroup, out var affixes);
            if (affixes == null) return;
            var element = SubAffixes.RandomElement();
            var affix = affixes.Values.ToList().Find(x => x.AffixID == element.Id);
            if (affix == null) return;
            element.IncreaseStep(affix.StepNum);
        }

        public void AddRandomRelicSubAffix(int count = 1)
        {
            GameData.RelicConfigData.TryGetValue(ItemId, out var config);
            if (config == null)
            {
                return;
            }
            GameData.RelicSubAffixData.TryGetValue(config.SubAffixGroup, out var affixes);

            if (affixes == null)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var affixConfig = affixes.Values.ToList().RandomElement();
                ItemSubAffix subAffix = new(affixConfig, 1);
                SubAffixes.Add(subAffix);
            }
        }

        #endregion

        #region Serialization

        public Material ToMaterialProto()
        {
            return new()
            {
                Tid = (uint)ItemId,
                Num = (uint)Count,
            };
        }

        public Relic ToRelicProto()
        {
            Relic relic = new()
            {
                Tid = (uint)ItemId,
                UniqueId = (uint)UniqueId,
                Level = (uint)Level,
                IsProtected = Locked,
                IsDiscarded = Discarded,
                BaseAvatarId = (uint)EquipAvatar,
                MainAffixId = (uint)MainAffix,
            };
            if (SubAffixes.Count >= 1)
            {
                foreach (var subAffix in SubAffixes)
                {
                    relic.SubAffixList.Add(subAffix.ToProto());
                }
            }
            return relic;
        }

        public Equipment ToEquipmentProto()
        {
            return new()
            {
                Tid = (uint)ItemId,
                UniqueId = (uint)UniqueId,
                Level = (uint)Level,
                Exp = (uint)Exp,
                IsProtected = Locked,
                Promotion = (uint)Promotion,
                Rank = (uint)Rank,
                BaseAvatarId = (uint)EquipAvatar
            };
        }

        public Item ToProto()
        {
            return new()
            {
                ItemId = (uint)ItemId,
                Num = (uint)Count,
                Level = (uint)Level,
                MainAffixId = (uint)MainAffix,
                Rank = (uint)Rank,
                Promotion = (uint)Promotion,
                UniqueId = (uint)UniqueId,
            };
        }

        #endregion
    }

    public class ItemSubAffix
    {
        public int Id { get; set; } // Affix id

        public int Count { get; set; }
        public int Step { get; set; }

        public ItemSubAffix() { }

        public ItemSubAffix(RelicSubAffixConfigExcel excel, int count)
        {
            Id = excel.AffixID;
            Count = count;
            Step = Extensions.RandomInt(0, excel.StepNum * count);
        }

        public ItemSubAffix(int id, int count, int step)
        {
            Id = id;
            Count = count;
            Step = step;
        }

        public void IncreaseStep(int stepNum)
        {
            Count++;
            Step += Extensions.RandomInt(0, stepNum);
        }

        public RelicAffix ToProto() => new()
        {
            AffixId = (uint)Id,
            Cnt = (uint)Count,
            Step = (uint)Step
        };
    }
}
