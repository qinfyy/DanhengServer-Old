using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Avatar;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using EggLink.DanhengServer.Server.Packet.Send.Scene;
using EggLink.DanhengServer.Util;
using System.Text.RegularExpressions;

namespace EggLink.DanhengServer.Game.Inventory
{
    public class InventoryManager(PlayerInstance player) : BasePlayerManager(player)
    {
        public InventoryData Data = DatabaseHelper.Instance!.GetInstanceOrCreateNew<InventoryData>(player.Uid);

        public void AddItem(ItemData itemData, bool notify = true)
        {
            PutItem(itemData.ItemId, itemData.Count, 
                itemData.Rank, itemData.Promotion, 
                itemData.Level, itemData.Exp, itemData.TotalExp, 
                itemData.MainAffix, itemData.SubAffixes,
                itemData.UniqueId);
            
            Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
            if (notify)
            {
                Player.SendPacket(new PacketScenePlaneEventScNotify(itemData));
            }
            DatabaseHelper.Instance?.UpdateInstance(Data);
        }

        public void AddItems(List<ItemData> items, bool notify = true)
        {
            foreach (var item in items)
            {
                AddItem(item.ItemId, items.Count, false, false);
            }
            if (notify)
            {
                Player.SendPacket(new PacketScenePlaneEventScNotify(items));
            }

            DatabaseHelper.Instance?.UpdateInstance(Data);
        }

        public ItemData? AddItem(int itemId, int count, bool notify = true, bool save = true, int rank = 1, int level = 1)
        {
            GameData.ItemConfigData.TryGetValue(itemId, out var itemConfig);
            if (itemConfig == null) return null;

            ItemData? itemData = null;

            switch (itemConfig.ItemMainType)
            {
                case ItemMainTypeEnum.Equipment:
                    itemData = PutItem(itemId, 1, rank: rank, level: level, uniqueId: ++Data.NextUniqueId);
                    break;
                case ItemMainTypeEnum.Usable:
                    switch (itemConfig.ItemSubType)
                    {
                        case ItemSubTypeEnum.HeadIcon:
                            Player.PlayerUnlockData!.HeadIcons.Add(itemId);
                            break;
                        case ItemSubTypeEnum.ChatBubble:
                            Player.PlayerUnlockData!.ChatBubbles.Add(itemId);
                            break;
                        case ItemSubTypeEnum.PhoneTheme:
                            Player.PlayerUnlockData!.PhoneThemes.Add(itemId);
                            break;
                        case ItemSubTypeEnum.Food:
                            itemData = PutItem(itemId, count);
                            break;
                    }
                    itemData ??= new()
                    {
                        ItemId = itemId,
                        Count = count,
                    };
                    break;
                case ItemMainTypeEnum.Relic:
                    var item = PutItem(itemId, 1, rank: 1, level: 0, uniqueId: ++Data.NextUniqueId);
                    item.AddRandomRelicMainAffix();
                    item.AddRandomRelicSubAffix(3);
                    Data.RelicItems.Find(x => x.UniqueId == item.UniqueId)!.SubAffixes = item.SubAffixes;
                    itemData = item;
                    break;
                case ItemMainTypeEnum.Virtual:
                    switch (itemConfig.ID)
                    {
                        case 1:
                            Player.Data.Hcoin += count;
                            break;
                        case 2:
                            Player.Data.Scoin += count;
                            break;
                        case 3:
                            Player.Data.Mcoin += count;
                            break;
                        case 11:
                            Player.Data.Stamina += count;
                            break;
                        case 22:
                            Player.Data.Exp += count;
                            Player.OnAddExp();
                            break;
                        case 32:
                            Player.Data.TalentPoints += count;
                            // TODO : send VirtualItemPacket instead of PlayerSyncPacket
                            break;
                    }
                    if (count != 0)
                    {
                        Player.SendPacket(new PacketPlayerSyncScNotify(Player.ToProto()));
                        itemData = new()
                        {
                            ItemId = itemId,
                            Count = count,
                        };
                    }
                    break;
                case ItemMainTypeEnum.AvatarCard:
                    // add avatar
                    var avatar = Player.AvatarManager?.GetAvatar(itemId);
                    if (avatar != null && avatar.Excel != null)
                    {
                        var rankUpItem = Player.InventoryManager!.GetItem(avatar.Excel.RankUpItemId);
                        if ((avatar.Rank + rankUpItem?.Count ?? 0) <= 5)
                            itemData = PutItem(avatar.Excel.RankUpItemId, 1);
                    }
                    else
                    {
                        Player.AddAvatar(itemId);
                        Player.SendPacket(new PacketAddAvatarScNotify(itemId));
                    }
                    break;
                default:
                    itemData = PutItem(itemId, Math.Min(count, itemConfig.PileLimit));
                    break;
            }

            if (itemData != null)
            {
                Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
                if (notify)
                {
                    itemData.Count = count;  // only notify the increase count
                    Player.SendPacket(new PacketScenePlaneEventScNotify(itemData));
                }
            }

            if (save)
                DatabaseHelper.Instance?.UpdateInstance(Data);

            return itemData;
        }

        public ItemData PutItem(int itemId, int count, int rank = 0, int promotion = 0, int level = 0, int exp = 0, int totalExp = 0, int mainAffix = 0, List<ItemSubAffix>? subAffixes = null, int uniqueId = 0)
        {
            if (promotion == 0 && level > 10)
            {
                promotion = GameData.GetMinPromotionForLevel(level);
            }
            var item = new ItemData()
            {
                ItemId = itemId,
                Count = count,
                Rank = rank,
                Promotion = promotion,
                Level = level,
                Exp = exp,
                TotalExp = totalExp,
                MainAffix = mainAffix,
                SubAffixes = subAffixes ?? [],
            };

            if (uniqueId > 0)
            {
                item.UniqueId = uniqueId;
            }

            switch (GameData.ItemConfigData[itemId].ItemMainType)
            {
                case ItemMainTypeEnum.Material:
                case ItemMainTypeEnum.Virtual:
                case ItemMainTypeEnum.Usable:
                case ItemMainTypeEnum.Mission:
                    var oldItem = Data.MaterialItems.Find(x => x.ItemId == itemId);
                    if (oldItem != null)
                    {
                        oldItem.Count += count;
                        item = oldItem;
                        break;
                    }
                    Data.MaterialItems.Add(item);
                    break;
                case ItemMainTypeEnum.Equipment:
                    Data.EquipmentItems.Add(item);
                    break;
                case ItemMainTypeEnum.Relic:
                    Data.RelicItems.Add(item);
                    break;
            }

            return item;
        }

        public void RemoveItem(int itemId, int count, int uniqueId = 0)
        {
            GameData.ItemConfigData.TryGetValue(itemId, out var itemConfig);
            if (itemConfig == null) return;
            ItemData? itemData = null;
            switch (itemConfig.ItemMainType)
            {
                case ItemMainTypeEnum.Material:
                case ItemMainTypeEnum.Mission:
                    var item = Data.MaterialItems.Find(x => x.ItemId == itemId);
                    if (item == null) return;
                    item.Count -= count;
                    if (item.Count <= 0)
                    {
                        Data.MaterialItems.Remove(item);
                        item.Count = 0;
                    }
                    itemData = item;
                    break;
                case ItemMainTypeEnum.Virtual:
                    switch (itemConfig.ID)
                    {
                        case 1:
                            Player.Data.Hcoin -= count;
                            break;
                        case 2:
                            Player.Data.Scoin -= count;
                            break;
                        case 3:
                            Player.Data.Mcoin -= count;
                            break;
                        case 32:
                            Player.Data.TalentPoints -= count;
                            break;
                    }
                    Player.SendPacket(new PacketPlayerSyncScNotify(Player.ToProto()));
                    break;
                case ItemMainTypeEnum.Equipment:
                    var equipment = Data.EquipmentItems.Find(x => x.UniqueId == uniqueId);
                    if (equipment == null) return;
                    Data.EquipmentItems.Remove(equipment);
                    equipment.Count = 0;
                    itemData = equipment;
                    break;
            }
            if (itemData != null)
            {
                Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
            }
            DatabaseHelper.Instance?.UpdateInstance(Data);
        }

        public ItemData? GetItem(int itemId)
        {
            GameData.ItemConfigData.TryGetValue(itemId, out var itemConfig);
            if (itemConfig == null) return null;
            switch (itemConfig.ItemMainType)
            {
                case ItemMainTypeEnum.Material:
                    return Data.MaterialItems.Find(x => x.ItemId == itemId);
                case ItemMainTypeEnum.Equipment:
                    return Data.EquipmentItems.Find(x => x.ItemId == itemId);
                case ItemMainTypeEnum.Relic:
                    return Data.RelicItems.Find(x => x.ItemId == itemId);
                case ItemMainTypeEnum.Virtual:
                    switch (itemConfig.ID)
                    {
                        case 1:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.Hcoin,
                            };
                        case 2:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.Scoin,
                            };
                        case 3:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.Mcoin,
                            };
                        case 11:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.Stamina,
                            };
                        case 22:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.Exp,
                            };
                        case 32:
                            return new ItemData()
                            {
                                ItemId = itemId,
                                Count = Player.Data.TalentPoints,
                            };
                    }
                    break;
            }
            return null;
        }

        public void HandlePlaneEvent(int eventId)
        {
            GameData.PlaneEventData.TryGetValue(eventId * 10 + Player.Data.WorldLevel, out var planeEvent);
            if (planeEvent == null) return;
            GameData.RewardDataData.TryGetValue(planeEvent.Reward, out var rewardData);
            if (rewardData == null) return;
            rewardData.GetItems().ForEach(x => AddItem(x.Item1, x.Item2));
        }

        public ItemData? ComposeItem(int composeId, int count)
        {
            GameData.ItemComposeConfigData.TryGetValue(composeId, out var composeConfig);
            if (composeConfig == null) return null;
            foreach (var cost in composeConfig.MaterialCost)
            {
                RemoveItem(cost.ItemID, cost.ItemNum * count);
            }

            RemoveItem(2, composeConfig.CoinCost * count);

            return AddItem(composeConfig.ItemID, count, false);
        }

        #region Equip

        public void EquipAvatar(int baseAvatarId, int equipmentUniqueId)
        {
            var itemData = Data.EquipmentItems.Find(x => x.UniqueId == equipmentUniqueId);
            var avatarData = Player.AvatarManager!.GetAvatar(baseAvatarId);
            if (itemData == null || avatarData == null) return;
            var oldItem = Data.EquipmentItems.Find(x => x.UniqueId == avatarData.EquipId);
            if (itemData.EquipAvatar > 0)  // already be dressed
            {
                var equipAvatar = Player.AvatarManager.GetAvatar(itemData.EquipAvatar);
                if (equipAvatar != null && oldItem != null)
                {
                    // switch
                    equipAvatar.EquipId = oldItem.UniqueId;
                    oldItem.EquipAvatar = equipAvatar.GetAvatarId();
                    Player.SendPacket(new PacketPlayerSyncScNotify(equipAvatar, oldItem));
                }
            } else
            {
                if (oldItem != null)
                {
                    oldItem.EquipAvatar = 0;
                }
            }
            itemData.EquipAvatar = avatarData.GetAvatarId();
            avatarData.EquipId = itemData.UniqueId;
            // save
            DatabaseHelper.Instance!.UpdateInstance(Data);
            DatabaseHelper.Instance!.UpdateInstance(Player.AvatarManager.AvatarData!);
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData, itemData));
        }

        public void EquipRelic(int baseAvatarId, int relicUniqueId, int slot)
        {
            var itemData = Data.RelicItems.Find(x => x.UniqueId == relicUniqueId);
            var avatarData = Player.AvatarManager!.GetAvatar(baseAvatarId);
            if (itemData == null || avatarData == null) return;
            avatarData.Relic.TryGetValue(slot, out int id);
            var oldItem = Data.RelicItems.Find(x => x.UniqueId == id);

            if (itemData.EquipAvatar > 0)  // already be dressed
            {
                var equipAvatar = Player.AvatarManager!.GetAvatar(itemData.EquipAvatar);
                if (equipAvatar != null && oldItem != null)
                {
                    // switch
                    equipAvatar.Relic[slot] = oldItem.UniqueId;
                    oldItem.EquipAvatar = equipAvatar.GetAvatarId();
                    Player.SendPacket(new PacketPlayerSyncScNotify(equipAvatar, oldItem));
                }
            } else
            {
                if (oldItem != null)
                {
                    oldItem.EquipAvatar = 0;
                }
            }
            itemData.EquipAvatar = avatarData.GetAvatarId();
            avatarData.Relic[slot] = itemData.UniqueId;
            // save
            DatabaseHelper.Instance!.UpdateInstance(Data);
            DatabaseHelper.Instance!.UpdateInstance(Player.AvatarManager.AvatarData!);
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData, itemData));
        }

        public void UnequipRelic(int baseAvatarId, int slot)
        {
            var avatarData = Player.AvatarManager!.GetAvatar(baseAvatarId);
            if (avatarData == null) return;
            avatarData.Relic.TryGetValue(slot, out var uniqueId);
            var itemData = Data.RelicItems.Find(x => x.UniqueId == uniqueId);
            if (itemData == null) return;
            avatarData.Relic.Remove(slot);
            itemData.EquipAvatar = 0;
            DatabaseHelper.Instance!.UpdateInstance(Data);
            DatabaseHelper.Instance!.UpdateInstance(Player.AvatarManager.AvatarData!);
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData, itemData));
        }

        public List<ItemData> LevelUpAvatar(int baseAvatarId, ItemCostData item)
        {
            var avatarData = Player.AvatarManager!.GetAvatar(baseAvatarId);
            if (avatarData == null) return [];
            GameData.AvatarPromotionConfigData.TryGetValue(avatarData.AvatarId * 10 + avatarData.Promotion, out var promotionConfig);
            if (promotionConfig == null) return [];
            var exp = 0;

            foreach (var cost in item.ItemList)
            {
                GameData.ItemConfigData.TryGetValue((int)cost.PileItem.ItemId, out var itemConfig);
                if (itemConfig == null) continue;
                exp += itemConfig.Exp * (int)cost.PileItem.ItemNum;
            }

            // payment
            int costScoin = exp / 10;
            if (Player.Data.Scoin < costScoin) return [];
            foreach (var cost in item.ItemList)
            {
                RemoveItem((int)cost.PileItem.ItemId, (int)cost.PileItem.ItemNum);
            }
            RemoveItem(2, costScoin);

            int maxLevel = promotionConfig.MaxLevel;
            int curExp = avatarData.Exp;
            int curLevel = avatarData.Level;
            int nextLevelExp = GameData.GetAvatarExpRequired(avatarData.Excel!.ExpGroup, avatarData.Level);
            do
            {
                int toGain;
                if (curExp + exp >= nextLevelExp)
                {
                    toGain = nextLevelExp - curExp;
                } else
                {
                    toGain = exp;
                }
                curExp += toGain;
                exp -= toGain;
                // level up
                if (curExp >= nextLevelExp)
                {
                    curExp = 0;
                    curLevel++;
                    nextLevelExp = GameData.GetAvatarExpRequired(avatarData.Excel!.ExpGroup, curLevel);
                }
            } while (exp > 0 && nextLevelExp > 0 && curLevel < maxLevel);

            avatarData.Level = curLevel;
            avatarData.Exp = curExp;
            DatabaseHelper.Instance!.UpdateInstance(Player.AvatarManager.AvatarData!);
            // leftover
            List<ItemData> list = [];
            var leftover = exp;
            while (leftover > 0)
            {
                var gain = false;
                foreach (var expItem in GameData.AvatarExpItemConfigData.Values.Reverse())
                {
                    if (leftover >= expItem.Exp)
                    {
                        // add
                        list.Add(PutItem(expItem.ItemID, 1));
                        leftover -= expItem.Exp;
                        gain = true;
                        break;
                    }
                }
                if (!gain)
                {
                    break;  // no more item
                }
            }
            if (list.Count > 0)
            {
                Player.SendPacket(new PacketPlayerSyncScNotify(list));
            }
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData));

            return list;
        }

        public List<ItemData> LevelUpEquipment(int equipmentUniqueId, ItemCostData item)
        {
            var itemData = Data.EquipmentItems.Find(x => x.UniqueId == equipmentUniqueId);
            if (itemData == null) return [];
            GameData.EquipmentPromotionConfigData.TryGetValue(itemData.ItemId * 10 + itemData.Promotion, out var equipmentPromotionConfig);
            GameData.EquipmentConfigData.TryGetValue(itemData.ItemId, out var equipmentConfig);
            if (equipmentConfig == null || equipmentPromotionConfig == null) return [];
            var exp = 0;

            foreach (var cost in item.ItemList)
            {
                if (cost.PileItem == null)
                {
                    // TODO : add equipment
                    exp += 100;
                } else
                {
                    GameData.ItemConfigData.TryGetValue((int)cost.PileItem.ItemId, out var itemConfig);
                    if (itemConfig == null) continue;
                    exp += itemConfig.Exp * (int)cost.PileItem.ItemNum;
                }
            }

            // payment
            int costScoin = exp / 2;
            if (Player.Data.Scoin < costScoin) return [];
            foreach (var cost in item.ItemList)
            {
                if (cost.PileItem == null)
                {
                    // TODO : add equipment
                    var costItem = Data.EquipmentItems.Find(x => x.UniqueId == cost.EquipmentUniqueId);
                    if (costItem == null) continue;
                    RemoveItem(costItem.ItemId, 1, (int)cost.EquipmentUniqueId);
                } else
                {
                    RemoveItem((int)cost.PileItem.ItemId, (int)cost.PileItem.ItemNum);
                }
            }
            RemoveItem(2, costScoin);

            int maxLevel = equipmentPromotionConfig.MaxLevel;
            int curExp = itemData.Exp;
            int curLevel = itemData.Level;
            int nextLevelExp = GameData.GetEquipmentExpRequired(equipmentConfig.ExpType, itemData.Level);
            do
            {
                int toGain;
                if (curExp + exp >= nextLevelExp)
                {
                    toGain = nextLevelExp - curExp;
                } else
                {
                    toGain = exp;
                }
                curExp += toGain;
                exp -= toGain;
                // level up
                if (curExp >= nextLevelExp)
                {
                    curExp = 0;
                    curLevel++;
                    nextLevelExp = GameData.GetEquipmentExpRequired(equipmentConfig.ExpType, curLevel);
                }
            } while (exp > 0 && nextLevelExp > 0 && curLevel < maxLevel);

            itemData.Level = curLevel;
            itemData.Exp = curExp;
            DatabaseHelper.Instance!.UpdateInstance(Data);
            // leftover
            List<ItemData> list = [];
            var leftover = exp;
            while (leftover > 0)
            {
                var gain = false;
                foreach (var expItem in GameData.EquipmentExpItemConfigData.Values.Reverse())
                {
                    if (leftover >= expItem.ExpProvide)
                    {
                        // add
                        list.Add(PutItem(expItem.ItemID, 1));
                        leftover -= expItem.ExpProvide;
                        gain = true;
                        break;
                    }
                }
                if (!gain)
                {
                    break;  // no more item
                }
            }
            if (list.Count > 0)
            {
                Player.SendPacket(new PacketPlayerSyncScNotify(list));
            }
            Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
            return list;
        }

        public void RankUpAvatar(int baseAvatarId, ItemCostData costData)
        {
            foreach (var cost in costData.ItemList)
            {
                RemoveItem((int)cost.PileItem.ItemId, (int)cost.PileItem.ItemNum);
            }
            var avatarData = Player.AvatarManager!.GetAvatar(baseAvatarId);
            if (avatarData == null) return;
            avatarData.Rank++;
            DatabaseHelper.Instance!.UpdateInstance(Player.AvatarManager.AvatarData!);
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData));
        }

        public void RankUpEquipment(int equipmentUniqueId, ItemCostData costData)
        {
            var rank = 0;
            foreach (var cost in costData.ItemList)
            {
                var costItem = Data.EquipmentItems.Find(x => x.UniqueId == cost.EquipmentUniqueId);
                if (costItem == null) continue;
                RemoveItem(costItem.ItemId, 0, (int)cost.EquipmentUniqueId);
                rank++;
            }
            var itemData = Data.EquipmentItems.Find(x => x.UniqueId == equipmentUniqueId);
            if (itemData == null) return;
            itemData.Rank += rank;
            DatabaseHelper.Instance!.UpdateInstance(Data);
            Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
        }

        #endregion
    }
}
