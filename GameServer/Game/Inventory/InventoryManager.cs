using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Inventory
{
    public class InventoryManager : BasePlayerManager
    {
        public InventoryData Data;
        public InventoryManager(PlayerInstance player) : base(player)
        {
            var inventory = DatabaseHelper.Instance?.GetInstance<InventoryData>(player.Uid);
            if (inventory == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new InventoryData()
                {
                    Uid = player.Uid,
                });
                inventory = DatabaseHelper.Instance?.GetInstance<InventoryData>(player.Uid);
            }
            Data = inventory!;
        }

        public ItemData? AddItem(int itemId, int count, bool notify = true)
        {
            GameData.ItemConfigData.TryGetValue(itemId, out var itemConfig);
            if (itemConfig == null) return null;

            ItemData? itemData = null;

            switch (itemConfig.ItemMainType)
            {
                case ItemMainTypeEnum.Equipment:
                    itemData = PutItem(itemId, 1, rank: 1, level: 1, uniqueId: ++Data.NextUniqueId);
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
                    }
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
                    Player.SendPacket(new PacketScenePlaneEventScNotify(itemData));
                }
            }

            DatabaseHelper.Instance?.UpdateInstance(Data);

            return itemData;
        }

        public ItemData PutItem(int itemId, int count, int rank = 0, int promotion = 0, int level = 0, int exp = 0, int totalExp = 0, int mainAffix = 0, List<ItemSubAffix>? subAffixes = null, int uniqueId = 0)
        {
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

        public void RemoveItem(int itemId, int count)
        {
            GameData.ItemConfigData.TryGetValue(itemId, out var itemConfig);
            if (itemConfig == null) return;
            ItemData? itemData = null;
            switch (itemConfig.ItemMainType)
            {
                case ItemMainTypeEnum.Material:
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
                    break;
            }
            if (itemData != null)
            {
                Player.SendPacket(new PacketPlayerSyncScNotify(itemData));
            }
            DatabaseHelper.Instance?.UpdateInstance(Data);
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
            Player.SendPacket(new PacketPlayerSyncScNotify(avatarData));
        }

        #endregion
    }
}
