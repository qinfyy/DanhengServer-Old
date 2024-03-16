using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Server.Packet.Send.Scene;

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

        public void SyncEntity()
        {
            bool refreshed = false;
            var oldGroupId = new List<int>();
            foreach (var entity in scene.Entities.Values)
            {
                if (!oldGroupId.Contains(entity.GroupID))
                    oldGroupId.Add(entity.GroupID);
            }

            var removeList = new List<IGameEntity>();

            foreach (var group in scene.FloorInfo!.Groups.Values)
            {
                if (group.LoadSide == GroupLoadSideEnum.Client)
                {
                    continue;
                }

                if (oldGroupId.Contains(group.Id))  // check if it should be unloaded
                {
                    if (group.UnloadCondition.IsTrue(scene.Player.MissionManager!.Data, false) || group.ForceUnloadCondition.IsTrue(scene.Player.MissionManager!.Data, false))
                    {
                        foreach (var entity in scene.Entities.Values)
                        {
                            if (entity.GroupID == group.Id)
                            {
                                scene.RemoveEntity(entity);
                                removeList.Add(entity);
                                refreshed = true;
                            }
                        }
                    }
                } else  // check if it should be loaded
                {
                    refreshed = LoadGroup(group) || refreshed;
                    // LoadGroup will send the packet
                }
            }
            if (refreshed)
            {
                scene.Player.SendPacket(new PacketSceneGroupRefreshScNotify(null, removeList));
            }
        }

        public bool LoadGroup(GroupInfo info)
        {
            var missionData = scene.Player.MissionManager!.Data;
            if (!info.LoadCondition.IsTrue(missionData) || info.UnloadCondition.IsTrue(missionData, false) || info.ForceUnloadCondition.IsTrue(missionData, false))
            {
                return false;
            }

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

            return true;
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
                prop.SetState(PropStateEnum.CheckPointEnable);
            } else
            {
                prop.SetState(info.State);
            }

            if (group.SaveType == SaveTypeEnum.Save)
            {
                // load from database
                var propData = scene.Player.GetScenePropData(scene.FloorId, group.Id, info.ID);
                if (propData != null)
                {
                    prop.SetState(propData.State);
                }
            }
        }
    }
}
