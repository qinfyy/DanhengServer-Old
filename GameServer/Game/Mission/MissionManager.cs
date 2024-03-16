using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Mission;
using EggLink.DanhengServer.Enums;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Game.Scene.Entity;
using EggLink.DanhengServer.Server.Packet.Send.Mission;
using EggLink.DanhengServer.Server.Packet.Send.Player;
using System.Reflection;

namespace EggLink.DanhengServer.Game.Mission
{
    public class MissionManager : BasePlayerManager
    {
        public MissionData Data;
        public Dictionary<FinishActionTypeEnum, MissionFinishActionHandler> ActionHandlers = [];
        public MissionManager(PlayerInstance player) : base(player)
        {
            var mission = DatabaseHelper.Instance?.GetInstance<MissionData>(player.Uid);
            if (mission == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new MissionData()
                {
                    Uid = player.Uid,
                });
                mission = DatabaseHelper.Instance?.GetInstance<MissionData>(player.Uid);
            }
            Data = mission!;

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<MissionFinishActionAttribute>();
                if (attr != null)
                {
                    var handler = (MissionFinishActionHandler)Activator.CreateInstance(type, null)!;
                    ActionHandlers.Add(attr.FinishAction, handler);
                }
            }
        }

        public void AcceptMainMission(int missionId)
        {
            if (Data.MissionInfo.ContainsKey(missionId)) return;
            // Get entry sub mission
            GameData.MainMissionData.TryGetValue(missionId, out var mission);
            if (mission == null) return;

            Data.MissionInfo.Add(missionId, []);
            mission.MissionInfo?.StartSubMissionList.ForEach(AcceptSubMission);
        }

        public void AcceptSubMission(int missionId)
        {
            AcceptSubMission(missionId, true);
        }

        public Proto.MissionSync? AcceptSubMission(int missionId, bool sendPacket)
        {
            var mainMissionId = int.Parse(missionId.ToString()[..^2]);
            if (!Data.MissionInfo.TryGetValue(mainMissionId, out Dictionary<int, MissionInfo>? value)) return null;
            if (value == null || value.ContainsKey(missionId)) return null;
            // Get entry sub mission
            GameData.SubMissionData.TryGetValue(missionId, out var mission);
            if (mission == null) return null;

            value.Add(missionId, new MissionInfo()
            {
                Status = MissionPhaseEnum.Doing,
                MissionId = missionId,
            });
            var sync = new Proto.MissionSync();
            sync.MissionList.Add(new Proto.Mission()
            {
                Id = (uint)missionId,
                Status = Proto.MissionStatus.MissionDoing,
            });

            DatabaseHelper.Instance?.UpdateInstance(Data);
            if (sendPacket)
                Player.SendPacket(new PacketPlayerSyncScNotify(sync));
            Player.SceneInstance!.SyncGroupInfo();
            return sync;
        }

        public void FinishSubMission(int missionId)
        {
            var mainMissionId = int.Parse(missionId.ToString()[..^2]);
            if (!Data.MissionInfo.TryGetValue(mainMissionId, out var value)) return;
            GameData.MainMissionData.TryGetValue(mainMissionId, out var mainMission);
            if (mainMission == null) return;
            if (value == null || !value.TryGetValue(missionId, out var mission)) return;
            if (mission.Status != MissionPhaseEnum.Doing) return;
            mission.Status = MissionPhaseEnum.Finish;
            var sync = new Proto.MissionSync();
            sync.MissionList.Add(new Proto.Mission()
            {
                Id = (uint)missionId,
                Status = Proto.MissionStatus.MissionFinish,
            });

            // get next sub mission
            foreach (var nextMission in mainMission.MissionInfo?.SubMissionList ?? [])
            {
                bool canAccept = true;
                foreach (var id in nextMission.TakeParamIntList)
                {
                    if (GetSubMissionStatus(id) != MissionPhaseEnum.Finish)
                    {
                        canAccept = false;
                    }
                }
                if (canAccept)
                {
                    var s = AcceptSubMission(nextMission.ID, false);
                    if (s != null)
                    {
                        sync.MissionList.Add(new Proto.Mission()
                        {
                            Id = (uint)nextMission.ID,
                            Status = Proto.MissionStatus.MissionDoing,
                        });
                    }
                }
                if (nextMission.FinishType == MissionFinishTypeEnum.PropState)
                {
                    foreach (var entity in Player.SceneInstance!.Entities.Values)
                    {
                        if (entity is EntityProp prop && prop.PropInfo.ID == nextMission.ParamInt2)
                        {
                            prop.SetState(PropStateEnum.Closed);
                        }
                    }
                }
            }
            if (mainMission.MissionInfo != null)
                HandleFinishAction(mainMission.MissionInfo, missionId);
            Player.SendPacket(new PacketPlayerSyncScNotify(sync));
            Player.SendPacket(new PacketStartFinishSubMissionScNotify(missionId));

            DatabaseHelper.Instance?.UpdateInstance(Data);
        }

        public void HandleFinishAction(Data.Config.MissionInfo info, int subMissionId) 
        {
            var subMission = info.SubMissionList.Find(x => x.ID == subMissionId);
            if (subMission == null) return;

            foreach (var action in subMission.FinishActionList)
            {
                HandleFinishAction(action);
            }
        }

        public void HandleFinishAction(Data.Config.FinishActionInfo actionInfo)
        {
            ActionHandlers.TryGetValue(actionInfo.FinishActionType, out var handler);
            handler?.OnHandle(actionInfo.FinishActionPara, Player);
        }

        public MissionPhaseEnum GetMainMissionStatus(int missionId)
        {
            if (Data.MainMissionInfo.TryGetValue(missionId, out var info))
            {
                return info!;
            }
            return MissionPhaseEnum.None;
        }

        public MissionPhaseEnum GetSubMissionStatus(int missionId)
        {
            var mainMissionId = int.Parse(missionId.ToString()[..^2]);
            if (Data.MissionInfo.TryGetValue(mainMissionId, out var info))
            {
                if (info.TryGetValue(missionId, out var mission))
                {
                    return mission.Status;
                }
            }
            return MissionPhaseEnum.None;
        }

        public Data.Config.SubMissionInfo? GetSubMissionInfo(int missionId)
        {
            var mainMissionId = int.Parse(missionId.ToString()[..^2]);
            if (GameData.MainMissionData.TryGetValue(mainMissionId, out var mainMission))
            {
                return mainMission.MissionInfo?.SubMissionList.Find(x => x.ID == missionId);
            }
            return null;
        }

        public List<int> GetRunningSubMissionIdList()
        {
            var list = new List<int>();
            foreach (var mainMission in Data.MissionInfo.Values)
            {
                foreach (var subMission in mainMission.Values)
                {
                    if (subMission.Status == MissionPhaseEnum.Doing)
                    {
                        list.Add(subMission.MissionId);
                    }
                }
            }
            return list;
        }

        public void OnBattleFinish(Proto.PVEBattleResultCsReq req)
        {
            foreach (var mission in GetRunningSubMissionIdList())
            {
                var subMission = GetSubMissionInfo(mission);
                if (subMission != null && subMission.FinishType == MissionFinishTypeEnum.StageWin && req.EndStatus == Proto.BattleEndStatus.BattleEndWin)
                {
                    FinishSubMission(mission);
                }
            }
        }
    }
}
