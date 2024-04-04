using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet.Send.Scene;
using EggLink.DanhengServer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public class EntityMonster(SceneInstance scene, Position pos, Position rot, int GroupID, int InstID, NPCMonsterDataExcel excel, MonsterInfo info) : IGameEntity
    {
        public int EntityID { get; set; } = 0;
        public int GroupID { get; set; } = GroupID;
        public Position Position { get; set; } = pos;
        public Position Rotation { get; set; } = rot;
        public int InstID { get; set; } = InstID;
        public NPCMonsterDataExcel MonsterData { get; set; } = excel;
        public MonsterInfo Info { get; set; } = info;
        public List<SceneBuff> BuffList { get; set; } = [];
        public SceneBuff? TempBuff { get; set; }
        public bool IsAlive { get; private set; } = true;

        public void AddBuff(SceneBuff buff)
        {
            BuffList.Add(buff);
            scene.Player.SendPacket(new PacketSyncEntityBuffChangeListScNotify(this, buff));
        }

        public void ApplyBuff(BattleInstance instance)
        {
            if (TempBuff != null)
            {
                instance.Buffs.Add(new MazeBuff(TempBuff));
                TempBuff = null;
            }
            foreach (var buff in BuffList)
            {
                if (buff.IsExpired())
                {
                    continue;
                }
                instance.Buffs.Add(new MazeBuff(buff));
            }
        }

        public int GetStageId()
        {
            return Info.EventID * 10 + scene.Player.Data.WorldLevel;
        }

        public List<ItemData> Kill()
        {
            scene.RemoveEntity(this);
            IsAlive = false;

            GameData.MonsterDropData.TryGetValue(MonsterData.ID * 10 + scene.Player.Data.WorldLevel, out var dropData);
            if (dropData == null) return [];
            var dropItems = dropData.CalculateDrop();
            scene.Player.InventoryManager!.AddItems(dropItems);

            // TODO: Rogue support
            // call mission handler
            scene.Player.MissionManager!.HandleFinishType(MissionFinishTypeEnum.KillMonster, this);
            return dropItems;
        }

        public SceneEntityInfo ToProto()
        {
            return new()
            {
                EntityId = (uint)EntityID,
                GroupId = (uint)GroupID,
                InstId = (uint)InstID,
                Motion = new()
                {
                    Pos = Position.ToProto(),
                    Rot = Rotation.ToProto()
                },
                NpcMonster = new()
                {
                    EventId = (uint)Info.EventID,
                    MonsterId = (uint)MonsterData.ID,
                    WorldLevel = (uint)scene.Player.Data.WorldLevel,
                }
            };
        }
    }
}
