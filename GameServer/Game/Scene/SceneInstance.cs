using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Game.Battle;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Proto;
using EggLink.DanhengServer.Server.Packet;
using EggLink.DanhengServer.Server.Packet.Send.Lineup;
using EggLink.DanhengServer.Server.Packet.Send.Scene;
using EggLink.DanhengServer.Util;

namespace EggLink.DanhengServer.Game.Scene
{
    public class SceneInstance
    {
        #region Data

        public PlayerInstance Player;
        public MazePlaneExcel Excel;
        public FloorInfo? FloorInfo;
        public int FloorId;
        public int PlaneId;
        public int EntryId;

        public int LastEntityId;
        public bool IsLoaded = false;

        public Dictionary<int, AvatarSceneInfo> AvatarInfo = [];
        public int LeaderEntityId;
        public Dictionary<int, IGameEntity> Entities = [];
        public List<EntityProp> HealingSprings = [];

        public SceneEntityLoader? EntityLoader;

        public SceneInstance(PlayerInstance player, MazePlaneExcel excel, int floorId, int entryId)
        {
            Player = player;
            Excel = excel;
            PlaneId = excel.PlaneID;
            FloorId = floorId;
            EntryId = entryId;

            SyncLineup(true, true);

            GameData.GetFloorInfo(PlaneId, FloorId, out FloorInfo);
            if (FloorInfo == null) return;

            switch (Excel.PlaneType)
            {
                default:
                    EntityLoader = new(this);
                    break;
            }

            EntityLoader.LoadEntity();
        }

        #endregion

        #region Scene Actions

        public void SyncLineup(bool notSendPacket = false, bool forceSetEntityId = false)
        {
            var oldAvatarInfo = AvatarInfo.Values.ToList();
            AvatarInfo.Clear();
            bool sendPacket = false;
            var AddAvatar = new List<IGameEntity>();
            var RemoveAvatar = new List<IGameEntity>();
            foreach (var avatar in Player.LineupManager?.GetAvatarsFromCurTeam() ?? [])
            {
                if (avatar == null) continue;
                avatar.AvatarInfo.PlayerData = Player.Data;
                if (forceSetEntityId)
                {
                    avatar.AvatarInfo.EntityId = ++LastEntityId;
                }
                var avatarInstance = oldAvatarInfo.Find(x => x.AvatarInfo.AvatarId == avatar.AvatarInfo.AvatarId);
                if (avatarInstance == null)
                {
                    if (avatar.AvatarInfo.EntityId == 0)
                    {
                        avatar.AvatarInfo.EntityId = ++LastEntityId;
                    }
                    AddAvatar.Add(avatar);
                    AvatarInfo.Add(avatar.AvatarInfo.EntityId, avatar);
                    sendPacket = true;
                } else
                {
                    AvatarInfo.Add(avatarInstance.AvatarInfo.EntityId, avatarInstance);
                }
            };
            foreach (var avatar in oldAvatarInfo)
            {
                if (AvatarInfo.Values.ToList().FindIndex(x => x.AvatarInfo.AvatarId == avatar.AvatarInfo.AvatarId) == -1)
                {
                    avatar.AvatarInfo.EntityId = 0;
                    RemoveAvatar.Add(avatar);
                    sendPacket = true;
                }
            }

            var LeaderAvatarId = Player.LineupManager?.GetCurLineup()?.LeaderAvatarId;
            var LeaderAvatarSlot = Player.LineupManager?.GetCurLineup()?.BaseAvatars?.FindIndex(x => x.BaseAvatarId == LeaderAvatarId);
            if (LeaderAvatarSlot == -1) LeaderAvatarSlot = 0;
            if (AvatarInfo.Count == 0) return;
            var info = AvatarInfo.Values.ToList()[LeaderAvatarSlot ?? 0];
            LeaderEntityId = info.AvatarInfo.EntityId;
            if (sendPacket && !notSendPacket)
            {
                Player.SendPacket(new PacketSceneGroupRefreshScNotify(AddAvatar, RemoveAvatar));
            }
        }

        public void SyncGroupInfo()
        {
            EntityLoader?.SyncEntity();
        }

        #endregion

        #region Scene Details

        public EntityProp? GetNearestSpring(long minDistSq)
        {
            EntityProp? spring = null;
            long springDist = 0;

            foreach (EntityProp prop in HealingSprings)
            {
                long dist = Player.Data?.Pos?.GetFast2dDist(prop.Position) ?? 1000000;
                if (dist > minDistSq) continue;

                if (spring == null || dist < springDist)
                {
                    spring = prop;
                    springDist = dist;
                }
            }

            return spring;
        }

        #endregion

        #region Entity Management

        public void AddEntity(IGameEntity entity)
        {
            AddEntity(entity, IsLoaded);
        }

        public void AddEntity(IGameEntity entity, bool SendPacket)
        {
            if (entity == null || entity.EntityID != 0) return;
            entity.EntityID = ++LastEntityId;

            Entities.Add(entity.EntityID, entity);
            if (SendPacket)
            {
                Player.SendPacket(new PacketSceneGroupRefreshScNotify(entity));
            }
        }

        public void RemoveEntity(IGameEntity monster)
        {
            RemoveEntity(monster, IsLoaded);
        }

        public void RemoveEntity(IGameEntity monster, bool SendPacket)
        {
            Entities.Remove(monster.EntityID);

            if (SendPacket)
            {
                Player.SendPacket(new PacketSceneGroupRefreshScNotify(null, monster));
            }
        }

        public List<T> GetEntitiesInGroup<T>(int groupID)
        {
            List<T> entities = [];
            foreach (var entity in Entities)
            {
                if (entity.Value.GroupID == groupID && entity.Value is T t)
                {
                    entities.Add(t);
                }
            }
            return entities;
        }

        #endregion

        #region Serialization

        public SceneInfo ToProto()
        {
            SceneInfo sceneInfo = new()
            {
                WorldId = (uint)Excel.WorldID,
                GameModeType = (uint)Excel.PlaneType,
                PlaneId = (uint)PlaneId,
                FloorId = (uint)FloorId,
                EntryId = (uint)EntryId,
            };
            var playerGroupInfo = new SceneEntityGroupInfo();  // avatar group
            foreach (var avatar in AvatarInfo)
            {
                playerGroupInfo.EntityList.Add(avatar.Value.AvatarInfo.ToSceneEntityInfo(avatar.Value.AvatarType));
            }
            if (playerGroupInfo.EntityList.Count > 0)
            {
                if (LeaderEntityId == 0)
                {
                    LeaderEntityId = AvatarInfo.Values.First().AvatarInfo.EntityId;
                    sceneInfo.LeaderEntityId = (uint)LeaderEntityId;
                } else
                {
                    sceneInfo.LeaderEntityId = (uint)LeaderEntityId;
                }
            }
            sceneInfo.EntityGroupList.Add(playerGroupInfo);

            List<SceneEntityGroupInfo> groups = [];  // other groups

            // add entities to groups
            foreach (var entity in Entities)
            {
                if (entity.Value.GroupID == 0) continue;
                if (groups.FindIndex(x => x.GroupId == entity.Value.GroupID) == -1)
                {
                    groups.Add(new SceneEntityGroupInfo()
                    {
                        GroupId = (uint)entity.Value.GroupID
                    });
                }
                groups[groups.FindIndex(x => x.GroupId == entity.Value.GroupID)].EntityList.Add(entity.Value.ToProto());
            }

            foreach (var group in groups)
            {
                sceneInfo.EntityGroupList.Add(group);
            }

            // custom save data
            Player.SceneData!.CustomSaveData.TryGetValue(EntryId, out var data);

            if (data != null)
            {
                foreach (var customData in data)
                {
                    sceneInfo.CustomSaveData.Add(new CustomSaveData()
                    {
                        GroupId = (uint)customData.Key,
                        SaveData = customData.Value
                    });
                }
            }

            // unlock section
            Player.SceneData!.UnlockSectionIdList.TryGetValue(FloorId, out var unlockSectionList);
            if (unlockSectionList != null)
            {
                foreach (var sectionId in unlockSectionList)
                {
                    sceneInfo.LightenSectionList.Add((uint)sectionId);
                }
            }

            return sceneInfo;
        }

        #endregion
    }

    public class AvatarSceneInfo(AvatarInfo avatarInfo, AvatarType avatarType, PlayerInstance Player) : IGameEntity
    {
        public AvatarInfo AvatarInfo = avatarInfo;
        public AvatarType AvatarType = avatarType;

        public int EntityID { get; set; } = avatarInfo.EntityId;
        public int GroupID { get; set; } = 0;

        public List<SceneBuff> BuffList = [];
        public void AddBuff(SceneBuff buff)
        {
            BuffList.Add(buff);
            Player.SendPacket(new PacketSyncEntityBuffChangeListScNotify(this, buff));
        }

        public void ApplyBuff(BattleInstance instance)
        {
            foreach (var buff in BuffList)
            {
                if (buff.IsExpired())
                {
                    continue;
                }
                instance.Buffs.Add(new MazeBuff(buff));
            }
        }

        public SceneEntityInfo ToProto()
        {
            return AvatarInfo.ToSceneEntityInfo(AvatarType);
        }
    }
}
