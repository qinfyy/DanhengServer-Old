using EggLink.DanhengServer.Proto;
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
    }

    public class ItemSubAffix
    {
        public int Id { get; set; } // Affix id

        public int Count { get; set; }
        public int Step { get; set; }

        public RelicAffix ToProto() => new()
        {
            AffixId = (uint)Id,
            Cnt = (uint)Count,
            Step = (uint)Step
        };
    }
}
