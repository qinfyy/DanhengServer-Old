using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Database.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using Newtonsoft.Json;
using SqlSugar;

namespace EggLink.DanhengServer.Database.Avatar
{
    [SugarTable("Avatar")]
    public class AvatarData : BaseDatabaseData
    {
        [SugarColumn(IsNullable = true, IsJson = true)]
        public List<AvatarInfo>? Avatars { get; set; }

        public List<int> AssistAvatars { get; set; } = [];
        public List<int> DisplayAvatars { get; set; } = [];
    }

    public class AvatarInfo
    {
        public int AvatarId { get; set; }
        public int HeroId { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Promotion { get; set; }
        public int Rewards { get; set; }
        public long Timestamp { get; set; }
        public int CurrentHp { get; set; } = 10000;
        public int CurrentSp { get; set; } = 10000;
        public int ExtraLineupHp { get; set; } = 10000;
        public int ExtraLineupSp { get; set; } = 10000;
        public int Rank { get; set; }
        public Dictionary<int, int> SkillTree { get; set; } = [];
        public int EquipId { get; set; } = 0;
        public Dictionary<int, int> Relic { get; set; } = [];

        [JsonIgnore()]
        public ItemData? EquipData { get; set; }  // for special avatar

        [JsonIgnore()]
        public AvatarConfigExcel? Excel;
        [JsonIgnore()]
        public int EntityId;
        [JsonIgnore()]
        public PlayerData? PlayerData;

        public AvatarInfo()
        {
            // only for db
        }

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

        public int GetCurHp(bool isExtraLineup)
        {
            return isExtraLineup ? ExtraLineupHp : CurrentHp;
        }

        public int GetCurSp(bool isExtraLineup)
        {
            return isExtraLineup ? ExtraLineupSp : CurrentSp;
        }

        public int GetAvatarId()
        {
            return HeroId > 0 ? HeroId : AvatarId;
        }

        public void SetCurHp(int value, bool isExtraLineup)
        {
            if (isExtraLineup)
            {
                ExtraLineupHp = value;
            }
            else
            {
                CurrentHp = value;
            }
        }

        public void SetCurSp(int value, bool isExtraLineup)
        {
            if (isExtraLineup)
            {
                ExtraLineupSp = value;
            }
            else
            {
                CurrentSp = value;
            }
        }

        public Proto.Avatar ToProto()
        {
            var proto = new Proto.Avatar()
            {
                BaseAvatarId = (uint)GetAvatarId(),  // 1005 will trigger npe
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

        public SceneEntityInfo ToSceneEntityInfo(AvatarType avatarType = AvatarType.AvatarFormalType)
        {
            return new()
            {
                EntityId = (uint)EntityId,
                Motion = new()
                {
                    Pos = PlayerData?.Pos?.ToProto() ?? new(),
                    Rot = PlayerData?.Rot?.ToProto() ?? new(),
                },
                Actor = new()
                {
                    BaseAvatarId = (uint)GetAvatarId(),
                    AvatarType = avatarType
                }
            };
        }

        public LineupAvatar ToLineupInfo(int slot, Lineup.LineupInfo info, AvatarType avatarType = AvatarType.AvatarFormalType)
        {
            return new()
            {
                Id = (uint)GetAvatarId(),
                Slot = (uint)slot,
                AvatarType = avatarType,
                Hp = info.IsExtraLineup() ? (uint)ExtraLineupHp : (uint)CurrentHp,
                SpBar = new()
                {
                    CurSp = info.IsExtraLineup() ? (uint)ExtraLineupSp : (uint)CurrentSp,
                    MaxSp = 10000,
                },
            };
        }

        public BattleAvatar ToBattleProto(Lineup.LineupInfo lineup, InventoryData inventory, AvatarType avatarType = AvatarType.AvatarFormalType)
        {
            var proto = new BattleAvatar()
            {
                Id = (uint)GetAvatarId(),
                AvatarType = avatarType,
                Level = (uint)Level,
                Promotion = (uint)Promotion,
                Rank = (uint)Rank,
                Index = (uint)lineup.GetSlot(GetAvatarId()),
                Hp = (uint)GetCurHp(lineup.LineupType != 0),
                SpBar = new()
                {
                    CurSp = (uint)GetCurSp(lineup.LineupType != 0),
                    MaxSp = 10000,
                },
                WorldLevel = (uint)(PlayerData?.WorldLevel ?? 0),
            };

            foreach (var skill in SkillTree)
            {
                proto.SkilltreeList.Add(new AvatarSkillTree()
                {
                    PointId = (uint)skill.Key,
                    Level = (uint)skill.Value
                });
            }

            foreach (var relic in Relic)
            {
                var item = inventory.RelicItems?.Find(item => item.UniqueId == relic.Value);
                if (item != null)
                {
                    var protoRelic = new BattleRelic()
                    {
                        Id = (uint)item.ItemId,
                        UniqueId = (uint)item.UniqueId,
                        Level = (uint)item.Level,
                        MainAffixId = (uint)item.MainAffix,
                    };

                    if (item.SubAffixes.Count >= 1)
                    {
                        foreach (var subAffix in item.SubAffixes)
                        {
                            protoRelic.SubAffixList.Add(subAffix.ToProto());
                        }
                    }

                    proto.RelicList.Add(protoRelic);
                }
            }

            if (EquipId != 0)
            {
                var item = inventory.EquipmentItems?.Find(item => item.UniqueId == EquipId);
                if (item != null)
                {
                    proto.EquipmentList.Add(new BattleEquipment()
                    {
                        Id = (uint)item.ItemId,
                        Level = (uint)item.Level,
                        Promotion = (uint)item.Promotion,
                        Rank = (uint)item.Rank,
                    });
                }
            } else if (EquipData != null)
            {
                proto.EquipmentList.Add(new BattleEquipment()
                {
                    Id = (uint)EquipData.ItemId,
                    Level = (uint)EquipData.Level,
                    Promotion = (uint)EquipData.Promotion,
                    Rank = (uint)EquipData.Rank,
                });
            }

            return proto;
        }

        public PlayerHeroBasicTypeInfo ToHeroProto()
        {
            var proto = new PlayerHeroBasicTypeInfo()
            {
                BasicType = (HeroBasicType)HeroId,
                Rank = (uint)Rank,
            };

            foreach (var skill in SkillTree)
            {
                proto.SkillTree.Add(new AvatarSkillTree()
                {
                    PointId = (uint)skill.Key,
                    Level = (uint)skill.Value
                });
            }

            return proto;
        }
    }
}
