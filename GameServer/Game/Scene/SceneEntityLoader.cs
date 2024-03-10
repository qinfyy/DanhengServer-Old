using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Scene.Entity;

namespace EggLink.DanhengServer.Game.Scene
{
    public class SceneEntityLoader(SceneInstance scene)
    {
        public void LoadEntity()
        {
            if (scene.IsLoaded) return;

            foreach (var group in scene?.FloorInfo?.Groups.Values!)  // Sanity check in SceneInstance
            {
                if (group.LoadSide == GroupLoadSideEnum.Client)
                {
                    continue;
                }

                LoadGroup(group);
            }
            scene.IsLoaded = true;
        }

        public void LoadGroup(GroupInfo info)
        {
            foreach (var npc in info.NPCList)
            {
                try
                {
                    LoadNpc(npc, info);
                } catch
                {
                }
            }

            foreach (var monster in info.MonsterList)
            {
                try
                {
                    LoadMonster(monster, info);
                } catch
                {
                }
            }

            foreach (var prop in info.PropList)
            {
                try
                {
                    LoadProp(prop, info);
                } catch
                {
                }
            }
        }

        public void LoadNpc(NpcInfo info, GroupInfo group)
        {
            if (info.IsClientOnly || info.IsDelete)
            {
                return;
            }
            if (!GameData.NpcDataData.ContainsKey(info.NPCID))
            {
                return;
            }
            bool hasDuplicateNpcId = false;
            foreach (IGameEntity entity in scene.Entities.Values)
            {
                if (entity is EntityNpc eNpc && eNpc.NpcId == info.NPCID)
                {
                    hasDuplicateNpcId = true;
                    break;
                }
            }
            if (hasDuplicateNpcId)
            {
                return;
            }
            EntityNpc npc = new(scene, group, info);
            scene.AddEntity(npc);
        }

        public void LoadMonster(MonsterInfo info, GroupInfo group)
        {
            if (info.IsClientOnly || info.IsDelete)
            {
                return;
            }

            GameData.NpcMonsterDataData.TryGetValue(info.NPCMonsterID, out var excel);
            if (excel == null)
            {
                return;
            }

            EntityMonster entity = new(scene ,info.ToPositionProto(), info.ToRotationProto(), group.Id, excel.ID, excel, info);
            scene.AddEntity(entity);
        }

        public void LoadProp(PropInfo info, GroupInfo group)
        {
            if (info.IsClientOnly || info.IsDelete)
            {
                return;
            }

            GameData.MazePropData.TryGetValue(info.PropID, out var excel);
            if (excel == null)
            {
                return;
            }

            var prop = new EntityProp(scene, excel, group, info);

            scene.AddEntity(prop);

            if (excel.PropType == PropTypeEnum.PROP_SPRING)
            {
                scene.HealingSprings.Add(prop);
                prop.State = PropStateEnum.CheckPointEnable;
            } else
                prop.State = PropStateEnum.Open;
        }
    }
}
