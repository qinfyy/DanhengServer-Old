using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("giveall", "Give all items in the category to player", "giveall <avatar/equipment> r<rank> l<level> x<amount>")]
    public class CommandGiveall : ICommand
    {
        [CommandMethod("0 avatar")]
        public void GiveAllAvatar(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var player = arg.Target.Player;
            if (player == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }
            arg.CharacterArgs.TryGetValue("r", out var rankStr);
            arg.CharacterArgs.TryGetValue("l", out var levelStr);
            rankStr ??= "1";
            levelStr ??= "1";
            if (!int.TryParse(rankStr, out var rank) || !int.TryParse(levelStr, out var level))
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            var avatarList = GameData.AvatarConfigData.Values;
            foreach (var avatar in avatarList)
            {
                if (player.AvatarManager!.GetAvatar(avatar.AvatarID) == null)
                {
                    player.InventoryManager!.AddItem(avatar.AvatarID, 1, false, false);
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Level = Math.Max(Math.Min(level, 80), 0);
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Promotion = GameData.GetMinPromotionForLevel(Math.Max(Math.Min(level, 80), 0));
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Rank = Math.Max(Math.Min(rank, 6), 0);
                } else
                {
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Level = Math.Max(Math.Min(level, 80), 0);
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Promotion = GameData.GetMinPromotionForLevel(Math.Max(Math.Min(level, 80), 0));
                    player.AvatarManager!.GetAvatar(avatar.AvatarID)!.Rank = Math.Max(Math.Min(rank, 6), 0);
                }
            }

            player.SendPacket(new PacketPlayerSyncScNotify(player.AvatarManager!.AvatarData.Avatars));
            
            DatabaseHelper.Instance?.UpdateInstance(player.AvatarManager!.AvatarData);
            DatabaseHelper.Instance?.UpdateInstance(player.InventoryManager!.Data);

            arg.SendMsg($"Give all avatars to {player.Uid}");
        }

        [CommandMethod("0 equipment")]
        public void GiveAllLightcone(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var player = arg.Target.Player;
            if (player == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            arg.CharacterArgs.TryGetValue("r", out var rankStr);
            arg.CharacterArgs.TryGetValue("l", out var levelStr);
            rankStr ??= "1";
            levelStr ??= "1";
            if (!int.TryParse(rankStr, out var rank) || !int.TryParse(levelStr, out var level))
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            var lightconeList = GameData.EquipmentConfigData.Values;
            var isLast = false;
            foreach (var lightcone in lightconeList)
            {
                if (lightconeList.Last().EquipmentID == lightcone.EquipmentID)
                {
                    isLast = true;
                }
                player.InventoryManager!.AddItem(lightcone.EquipmentID, 1, false, isLast, Math.Max(Math.Min(rank, 5), 0), Math.Max(Math.Min(level, 80), 0));
            }
            arg.SendMsg($"Give all lightcones to {player.Uid}");
        }

        [CommandMethod("0 material")]
        public void GiveAllMaterial(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var player = arg.Target.Player;
            if (player == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            arg.CharacterArgs.TryGetValue("x", out var amountStr);
            amountStr ??= "1";
            if (!int.TryParse(amountStr, out var amount))
            {
                arg.SendMsg("Invalid arguments.");
                return;
            }

            var materialList = GameData.ItemConfigData.Values;
            foreach (var material in materialList)
            {
                if (material.ItemMainType == Enums.Item.ItemMainTypeEnum.Material)
                {
                    player.InventoryManager!.AddItem(material.ID, amount, false, false);
                }
            }

            DatabaseHelper.Instance?.UpdateInstance(player.InventoryManager!.Data);

            arg.SendMsg($"Give all materials to {player.Uid}");
        }

        [CommandMethod("0 unlock")]
        public void GiveAllUnlock(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var player = arg.Target.Player;
            if (player == null)
            {
                arg.SendMsg("Target not found.");
                return;
            }

            var materialList = GameData.ItemConfigData.Values;
            foreach (var material in materialList)
            {
                if (material.ItemMainType == Enums.Item.ItemMainTypeEnum.Usable)
                {
                    if (material.ItemSubType == Enums.Item.ItemSubTypeEnum.HeadIcon || material.ItemSubType == Enums.Item.ItemSubTypeEnum.PhoneTheme || material.ItemSubType == Enums.Item.ItemSubTypeEnum.ChatBubble)
                    {
                        player.InventoryManager!.AddItem(material.ID, 1, false, false);
                    }
                }
            }

            DatabaseHelper.Instance?.UpdateInstance(player.InventoryManager!.Data);

            arg.SendMsg($"Give all materials to {player.Uid}");
        }
    }
}
