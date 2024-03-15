using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Battle;
using EggLink.DanhengServer.Server.Packet.Send.Lineup;
using EggLink.DanhengServer.Util;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Battle
{
    public class BattleManager(PlayerInstance player) : BasePlayerManager(player)
    {
        public void StartCocoonStage(int cocoonId, int wave, int worldLevel)
        {
            if (Player.BattleInstance != null) return;

            GameData.CocoonConfigData.TryGetValue(cocoonId * 100 + worldLevel, out var config);
            if (config == null)
            {
                Player.SendPacket(new PacketStartCocoonStageScRsp());
                return;
            }
            wave = Math.Min(Math.Max(wave, 1), config.MaxWave);

            int cost = config.StaminaCost * wave;
            if (Player.Data.Stamina < cost)
            {
                Player.SendPacket(new PacketStartCocoonStageScRsp());
                return;
            }

            List<StageConfigExcel> stageConfigExcels = [];
            for (int i = 0; i < wave; i++)
            {
                var stageId = config.StageIDList.RandomElement();
                GameData.StageConfigData.TryGetValue(stageId, out var stageConfig);
                if (stageConfig == null) continue;

                stageConfigExcels.Add(stageConfig);
            }

            if (stageConfigExcels.Count == 0)
            {
                Player.SendPacket(new PacketStartCocoonStageScRsp());
                return;
            }

            BattleInstance battleInstance = new(Player, Player.LineupManager.GetCurLineup()!, stageConfigExcels)
            {
                StaminaCost = cost,
                WorldLevel = config.WorldLevel,
                CocoonWave = wave,
                MappingInfoId = config.MappingInfoID,
            };

            Player.BattleInstance = battleInstance;

            Player.SendPacket(new PacketStartCocoonStageScRsp(battleInstance, cocoonId, wave));
        }

        public void EndBattle(PVEBattleResultCsReq req)
        {
            if (Player.BattleInstance == null)
            {
                Player.SendPacket(new PacketPVEBattleResultScRsp());
                return;
            }
            Player.BattleInstance.BattleEndStatus = req.EndStatus;
            var battle = Player.BattleInstance;
            bool updateStatus = true;
            bool teleportToAnchor = false;
            var minimumHp = 0;

            switch (req.EndStatus)
            {
                case BattleEndStatus.BattleEndWin:
                    // Remove monsters from the map - Could optimize it a little better
                    //for (var monster in battle.NpcMonsters)
                    //{
                    //    // Dont remove farmable monsters from the scene when they are defeated
                    //    if (monster.isFarmElement()) continue;
                    //    // Remove monster
                    //    player.SceneInstance.RemoveEntity(monster);
                    //}
                    // Drops
                    // Spend stamina
                    if (battle.StaminaCost > 0)
                    {
                        player.SpendStamina(battle.StaminaCost);
                    }
                    break;
                case BattleEndStatus.BattleEndLose:
                    // Set avatar hp to 20% if the player's party is downed
                    minimumHp = 2000;
                    teleportToAnchor = true;
                    break;
                case BattleEndStatus.BattleEndQuit:
                    updateStatus = false;
                    break;
                default:
                    updateStatus = false;
                    break;
            }

            if (updateStatus)
            {
                var lineup = player.LineupManager.GetCurLineup()!;
                // Update battle status
                foreach (var avatar in req.Stt.AvatarBattleList)
                {
                    var avatarInstance = player.AvatarManager!.GetAvatar((int)avatar.Id);
                    if (avatarInstance == null) continue;

                    var prop = avatar.AvatarStatus;
                    int curHp = (int)Math.Round(prop.LeftHp / prop.MaxHp * 10000);
                    int curSp = (int)prop.LeftSp * 100;

                    avatarInstance.SetCurHp(curHp, lineup.LineupType != 0);
                    avatarInstance.SetCurSp(curSp, lineup.LineupType != 0);
                }

                DatabaseHelper.Instance?.UpdateInstance(Player.AvatarManager!.AvatarData!);
                Player.SendPacket(new PacketSyncLineupNotify(battle.Lineup));
            }
            if (teleportToAnchor)
            {
                var anchorProp = player.SceneInstance?.GetNearestSpring(long.MaxValue);
                if (anchorProp != null && anchorProp.PropInfo != null)
                {
                    var anchor = player?.SceneInstance?.FloorInfo?.GetAnchorInfo(
                            anchorProp.PropInfo.AnchorGroupID,
                            anchorProp.PropInfo.AnchorID
                    );
                    if (anchor != null)
                    {
                        Player.MoveTo(anchor.ToPositionProto());
                    }
                }
            }

            Player.BattleInstance = null;
            Player.SendPacket(new PacketPVEBattleResultScRsp(req, Player, battle));
        }
    }
}
