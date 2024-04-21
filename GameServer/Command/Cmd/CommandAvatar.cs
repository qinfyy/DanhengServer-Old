using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Command.Cmd
{
    [CommandInfo("avatar", "Manage the player's avatar", "/avatar <talent [id/-1] [level]>/<get [id]>/<rank [id/-1] [rank]>/level [id/-1] [level]")]
    public class CommandAvatar : ICommand
    {
        [CommandMethod("talent")]
        public void SetTalent(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }
            if (arg.BasicArgs.Count < 2)
            {
                arg.SendMsg("Invalid arguments");
                return;
            }
            var Player = arg.Target.Player!;
            // change basic type
            var avatarId = arg.GetInt(0);
            var level = arg.GetInt(1);
            if (level < 0 || level > 10)
            {
                arg.SendMsg("Invalid talent level");
                return;
            }
            var player = arg.Target.Player!;
            if (avatarId == -1)
            {
                player.AvatarManager!.AvatarData.Avatars.ForEach(avatar =>
                {
                    if (avatar.HeroId > 0)
                    {
                        avatar.SkillTreeExtra.TryGetValue(avatar.HeroId, out var hero);
                        hero ??= [];
                        var excel = GameData.AvatarConfigData[avatar.HeroId];
                        excel.SkillTree.ForEach(talent =>
                        {
                            hero[talent.PointID] = Math.Min(level, talent.MaxLevel);
                        });
                    } else
                    {
                        avatar.Excel?.SkillTree.ForEach(talent =>
                        {
                            avatar.SkillTree![talent.PointID] = Math.Min(level, talent.MaxLevel);
                        });
                    }
                });
                arg.SendMsg($"Player has set all avatars' talents to level {level}");

                // save
                DatabaseHelper.Instance?.UpdateInstance(player.AvatarManager.AvatarData);

                // sync
                player.SendPacket(new PacketPlayerSyncScNotify(player.AvatarManager.AvatarData.Avatars));

                return;
            }
            var avatar = player.AvatarManager!.GetAvatar(avatarId);
            if (avatar == null)
            {
                arg.SendMsg("Avatar not found");
                return;
            }
            avatar.Excel?.SkillTree.ForEach(talent =>
            {
                avatar.SkillTree![talent.PointID] = Math.Min(level, talent.MaxLevel);
            });
            
            // save
            DatabaseHelper.Instance?.UpdateInstance(player.AvatarManager.AvatarData);

            // sync
            player.SendPacket(new PacketPlayerSyncScNotify(avatar));

            arg.SendMsg($"Player has set {avatarId} talents to level {level}");
        }

        [CommandMethod("get")]
        public void GetAvatar(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }

            if (arg.BasicArgs.Count < 1)
            {
                arg.SendMsg("Invalid arguments");
            }

            var id = arg.GetInt(0);
            arg.Target.Player!.AvatarManager!.AddAvatar(id);
            arg.SendMsg($"Player has gained avatar {id}");
        }

        [CommandMethod("rank")]
        public void SetRank(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }

            if (arg.BasicArgs.Count < 2)
            {
                arg.SendMsg("Invalid arguments");
            }

            var id = arg.GetInt(0);
            var rank = arg.GetInt(1);
            if (rank < 0 || rank > 6)
            {
                arg.SendMsg("Invalid rank");
                return;
            }
            if (id == -1)
            {
                arg.Target.Player!.AvatarManager!.AvatarData.Avatars.ForEach(avatar =>
                {
                    avatar.Rank = Math.Min(rank, 6);
                });
                arg.SendMsg($"Player has set all avatars' rank to {rank}");

                // save
                DatabaseHelper.Instance?.UpdateInstance(arg.Target.Player!.AvatarManager.AvatarData);

                // sync
                arg.Target.SendPacket(new PacketPlayerSyncScNotify(arg.Target.Player!.AvatarManager.AvatarData.Avatars));
            }
            else
            {
                var avatar = arg.Target.Player!.AvatarManager!.GetAvatar(id);
                if (avatar == null)
                {
                    arg.SendMsg("Avatar not found");
                    return;
                }
                avatar.Rank = Math.Min(rank, 6);

                // save
                DatabaseHelper.Instance?.UpdateInstance(arg.Target.Player!.AvatarManager.AvatarData);

                // sync
                arg.Target.SendPacket(new PacketPlayerSyncScNotify(avatar));

                arg.SendMsg($"Player has set avatar {id} rank to {rank}");
            }
        }

        [CommandMethod("level")]
        public void SetLevel(CommandArg arg)
        {
            if (arg.Target == null)
            {
                arg.SendMsg("Player not found");
                return;
            }

            if (arg.BasicArgs.Count < 2)
            {
                arg.SendMsg("Invalid arguments");
            }

            var id = arg.GetInt(0);
            var level = arg.GetInt(1);
            if (level < 1 || level > 80)
            {
                arg.SendMsg("Invalid level");
                return;
            }

            if (id == -1)
            {
                arg.Target.Player!.AvatarManager!.AvatarData.Avatars.ForEach(avatar =>
                {
                    avatar.Level = Math.Min(level, 80);
                    avatar.Promotion = GameData.GetMinPromotionForLevel(avatar.Level);
                });
                arg.SendMsg($"Player has set all avatars' level to {level}");

                // save
                DatabaseHelper.Instance?.UpdateInstance(arg.Target.Player!.AvatarManager.AvatarData);

                // sync
                arg.Target.SendPacket(new PacketPlayerSyncScNotify(arg.Target.Player!.AvatarManager.AvatarData.Avatars));
            }
            else
            {
                var avatar = arg.Target.Player!.AvatarManager!.GetAvatar(id);
                if (avatar == null)
                {
                    arg.SendMsg("Avatar not found");
                    return;
                }
                avatar.Level = Math.Min(level, 80);
                avatar.Promotion = GameData.GetMinPromotionForLevel(avatar.Level);

                // save
                DatabaseHelper.Instance?.UpdateInstance(arg.Target.Player!.AvatarManager.AvatarData);

                // sync
                arg.Target.SendPacket(new PacketPlayerSyncScNotify(avatar));

                arg.SendMsg($"Player has set avatar {id} level to {level}");
            }
        }
    }
}
