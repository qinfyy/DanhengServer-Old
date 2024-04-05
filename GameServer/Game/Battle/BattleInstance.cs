using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Proto;

namespace EggLink.DanhengServer.Game.Battle
{
    public class BattleInstance(PlayerInstance player, Database.Lineup.LineupInfo lineup, List<StageConfigExcel> stages) : BasePlayerManager(player)
    {
        public int BattleId { get; set; } = ++player.NextBattleId;
        public int StaminaCost { get; set; }
        public int WorldLevel { get; set; }
        public int CocoonWave { get; set; }
        public int MappingInfoId { get; set; }
        public int RoundLimit { get; set; }
        public int StageId { get; set; } = stages.Count > 0 ? stages[0].StageID : 0;  // Set to 0 when hit monster
        public BattleEndStatus BattleEndStatus { get; set; }

        public List<ItemData> MonsterDropItems { get; set; } = [];

        public List<StageConfigExcel> Stages { get; set; } = stages;
        public Database.Lineup.LineupInfo Lineup { get; set; } = lineup;
        public List<EntityMonster> EntityMonsters { get; set; } = [];
        public List<AvatarSceneInfo> AvatarInfo { get; set; } = [];
        public List<MazeBuff> Buffs { get; set; } = [];

        public BattleInstance(PlayerInstance player, Database.Lineup.LineupInfo lineup, List<EntityMonster> monsters) : this(player, lineup, new List<StageConfigExcel>())
        {
            foreach (var monster in monsters)
            {
                var id = monster.GetStageId();
                GameData.StageConfigData.TryGetValue(id, out var stage);
                if (stage != null)
                {
                    Stages.Add(stage);
                }
            }
            EntityMonsters = monsters;
            StageId = Stages[0].StageID;
        }

        public ItemList GetDropItemList()
        {
            var list = new ItemList();

            foreach (var item in MonsterDropItems)
            {
                list.ItemList_.Add(item.ToProto());
            }

            return list;
        }

        public SceneBattleInfo ToProto()
        {
            var proto = new SceneBattleInfo()
            {
                BattleId = (uint)BattleId,
                WorldLevel = (uint)WorldLevel,
                RoundsLimit = (uint)RoundLimit,
                StageId = (uint)StageId,
                LogicRandomSeed = (uint)Random.Shared.Next(),
            };

            foreach (var wave in Stages)
            {
                proto.MonsterWaveList.AddRange(wave.ToProto());
            }

            foreach (var avatar in Lineup.BaseAvatars!)
            {
                AvatarInfo? avatarInstance = null;
                var avatarType = AvatarType.AvatarFormalType;
                if (avatar.AssistUid != 0)
                {
                    var player = DatabaseHelper.Instance!.GetInstance<AvatarData>(avatar.AssistUid);
                    if (player != null)
                    {
                        avatarInstance = player.Avatars!.Find(item => item.GetAvatarId() == avatar.BaseAvatarId);
                        avatarType = AvatarType.AvatarAssistType;
                    }
                } else if (avatar.SpecialAvatarId != 0)
                {
                    GameData.SpecialAvatarData.TryGetValue(avatar.SpecialAvatarId, out var specialAvatar);
                    if (specialAvatar != null)
                    {
                        avatarInstance = specialAvatar.ToAvatarData(Player.Uid);
                        avatarType = AvatarType.AvatarTrialType;
                    }
                } else
                {
                    avatarInstance = Player.AvatarManager!.GetAvatar(avatar.BaseAvatarId);
                }
                if (avatarInstance == null) continue;

                proto.BattleAvatarList.Add(avatarInstance.ToBattleProto(Player.LineupManager!.GetCurLineup()!, Player.InventoryManager!.Data, avatarType));
            }

            foreach (var monster in EntityMonsters)
            {
                monster.ApplyBuff(this);
            }

            foreach (var avatar in AvatarInfo)
            {
                avatar.ApplyBuff(this);
            }

            proto.BuffList.AddRange(Buffs.Select(buff => buff.ToProto(this)));
            return proto;
        }
    }
}
