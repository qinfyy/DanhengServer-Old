using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Data.Config;
using EggLink.DanhengServer.Data.Excel;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Avatar;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Proto;

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
        public int LeaderAvatarId;
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

            SyncLineup();

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

        public void SyncLineup()
        {
            AvatarInfo = [];
            foreach (var avatar in Player.LineupManager?.GetCurLineup()?.BaseAvatars ?? [])
            {
                if (avatar.AssistUid != 0)
                {
                    var assistPlayer = DatabaseHelper.Instance?.GetInstance<AvatarData>(avatar.AssistUid);
                    if (assistPlayer != null)
                    {
                        var assistAvatar = assistPlayer.Avatars?.Find(x => x.AvatarId == avatar.BaseAvatarId);
                        if (assistAvatar != null)
                        {
                            AvatarInfo.Add(assistAvatar.AvatarId, new(assistAvatar, AvatarType.AvatarAssistType));
                        }
                    }
                } else if (avatar.SpecialAvatarId != 0)
                {

                } else
                {
                    var avatarData = Player.AvatarManager?.GetAvatar(avatar.BaseAvatarId);
                    if (avatarData?.AvatarId == avatar.BaseAvatarId)
                    {
                        avatarData.EntityId = ++LastEntityId;
                        AvatarInfo.Add(avatarData.EntityId, new(avatarData, AvatarType.AvatarFormalType));
                    }
                }
            };

            LeaderAvatarId = Player.LineupManager?.GetCurLineup()?.LeaderAvatarId ?? 0;
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
        }

        public void RemoveEntity(IGameEntity monster, bool SendPacket = false)
        {
            Entities.Remove(monster.EntityID);
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

            if (LeaderAvatarId != 0)
            {
                sceneInfo.LeaderEntityId = (uint)LeaderAvatarId;
            } else
            {
                LeaderAvatarId = AvatarInfo.Keys.First();
                sceneInfo.LeaderEntityId = (uint)LeaderAvatarId;
            }
            sceneInfo.EntityGroupList.Add(playerGroupInfo);

            List<SceneEntityGroupInfo> groups = [];  // other groups

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

            return sceneInfo;
        }

        #endregion
    }

    public class AvatarSceneInfo(AvatarInfo avatarInfo, AvatarType avatarType)
    {
        public AvatarInfo AvatarInfo = avatarInfo;
        public AvatarType AvatarType = avatarType;
    }
}
