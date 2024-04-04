using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.Scene.Entity
{
    public class EntityNpc(SceneInstance scene, GroupInfo group, NpcInfo npcInfo) : IGameEntity
    {
        public int EntityID { get; set; }
        public int GroupID { get; set; } = group.Id;
        public Position Position { get; set; } = npcInfo.ToPositionProto();
        public Position Rotation { get; set; } = npcInfo.ToRotationProto();
        public int NpcId { get; set; } = npcInfo.NPCID;
        public int InstId { get; set; } = npcInfo.ID;

        #region For Rogue

        public int RogueNpcId { get; set; }
        public bool IsFinishedTalk { get; set; }
        public int EventUniqueId { get; set; }

        #endregion

        public void AddBuff(SceneBuff buff)
        {
        }

        public void ApplyBuff(BattleInstance instance)
        {
        }

        public SceneEntityInfo ToProto()
        {
            SceneNpcInfo npc = new()
            {
                NpcId = (uint)NpcId,
            };
            if (RogueNpcId > 0)
            {
                //var rogue = new NpcRogueInfo()  // wait to update
                //{
                //    EventId = (uint)RogueNpcId,
                //    IsFinished = IsFinishedTalk,
                //    EventUniqueId = (uint)EventUniqueId,
                //};

                //npc.ExtraInfo.RogueInfo = rogue;
            }

            return new SceneEntityInfo()
            {
                EntityId = (uint)EntityID,
                GroupId = (uint)GroupID,
                Motion = new MotionInfo()
                {
                    Pos = Position.ToProto(),
                    Rot = Rotation.ToProto(),
                },
                InstId = (uint)InstId,
                Npc = npc,
            };
        }
    }
}
