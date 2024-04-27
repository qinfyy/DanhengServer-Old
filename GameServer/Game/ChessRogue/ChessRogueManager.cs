using EggLink.DanhengServer.Data;
using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.ChessRogue;
using EggLink.DanhengServer.Game.Player;
using EggLink.DanhengServer.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Game.ChessRogue
{
    public class ChessRogueManager(PlayerInstance player) : BasePlayerManager(player)
    {
        public ChessRogueNousData ChessRogueNousData { get; private set; } = DatabaseHelper.Instance!.GetInstanceOrCreateNew<ChessRogueNousData>(player.Uid);

        #region Dice Management

        public ChessRogueNousDiceData GetDice(int branchId)
        {
            ChessRogueNousData.RogueDiceData.TryGetValue(branchId, out var diceData);

            if (diceData == null)  // set to default
            {
                var branch = GameData.RogueNousDiceBranchData[branchId];
                var surface = branch.GetDefaultSurfaceList();
                return SetDice(branchId, surface.Select((id, i) => new { id, i }).ToDictionary(x => x.i + 1, x => x.id));  // convert to dictionary
            }

            return diceData;
        }

        public ChessRogueNousDiceData SetDice(int branchId, Dictionary<int, int> surfaceId)
        {
            ChessRogueNousData.RogueDiceData.TryGetValue(branchId, out var diceData);

            if (diceData == null)
            {
                diceData = new ChessRogueNousDiceData()
                {
                    BranchId = branchId,
                    Surfaces = surfaceId,
                };

                ChessRogueNousData.RogueDiceData[branchId] = diceData;
            }
            else
            {
                diceData.Surfaces = surfaceId;
            }

            DatabaseHelper.Instance!.UpdateInstance(ChessRogueNousData);

            return diceData;
        }

        public ChessRogueNousDiceData SetDice(int branchId, int index, int surfaceId)
        {
            ChessRogueNousData.RogueDiceData.TryGetValue(branchId, out var diceData);
            if (diceData == null)
            {
                // set to default
                var branch = GameData.RogueNousDiceBranchData[branchId];
                var surface = branch.GetDefaultSurfaceList();
                surface[index] = surfaceId;

                return SetDice(branchId, surface.Select((id, i) => new { id, i }).ToDictionary(x => x.i + 1, x => x.id));  // convert to dictionary
            } else
            {
                diceData.Surfaces[index] = surfaceId;
                DatabaseHelper.Instance!.UpdateInstance(ChessRogueNousData);

                return diceData;
            }
        }

        #endregion

        #region Serialization

        public ChessRogueGetInfo ToGetInfo()
        {
            var info = new ChessRogueGetInfo
            {
                AeonInfo = ToAeonInfo(),
                DiceInfo = ToDiceInfo(),
                RogueTalentInfo = ToTalentInfo(),
                RogueDifficultyInfo = new(),
            };

            foreach (var area in GameData.RogueDLCAreaData.Keys)
            {
                info.AreaIdList.Add((uint)area);
                info.ExploredAreaIdList.Add((uint)area);
            }


            foreach (var item in GameData.RogueNousDifficultyLevelData.Keys)
            {
                info.RogueDifficultyInfo.DifficultyId.Add((uint)item);
            }

            return info;
        }

        public ChessRogueCurrentInfo ToCurrentInfo()
        {
            var info = new ChessRogueCurrentInfo
            {
                RogueVersionId = 201,
                LevelInfo = ToLevelInfo(),
                RogueAeonInfo = ToRogueAeonInfo(),
                RogueDiceInfo = ToRogueDiceInfo(),
                RogueDifficultyInfo = new(),
                StoryInfo = new(),
                GameMiracleInfo = new(),
                RogueBuffInfo = new(),
            };

            foreach (var item in GameData.RogueNousDifficultyLevelData.Keys)
            {
                info.RogueDifficultyInfo.DifficultyId.Add((uint)item);
            }

            info.RogueGameInfo.AddRange(ToGameInfo());

            return info;
        }

        public ChessRogueQueryInfo ToQueryInfo()
        {
            var info = new ChessRogueQueryInfo
            {
                AeonInfo = ToAeonInfo(),
                RogueTalentInfo = ToTalentInfo(),
                RogueDifficultyInfo = new(),
            };

            foreach (var area in GameData.RogueDLCAreaData.Keys)
            {
                info.AreaIdList.Add((uint)area);
                info.ExploredAreaIdList.Add((uint)area);
            }

            foreach (var item in GameData.RogueNousDifficultyLevelData.Keys)
            {
                info.RogueDifficultyInfo.DifficultyId.Add((uint)item);
            }

            return info;
        }

        public ChessRogueLevelInfo ToLevelInfo()
        {
            var proto = new ChessRogueLevelInfo()
            {
                AreaInfo = new()
                {
                    Cell = new(),
                    GHIBONBOIMF = new(),
                }
            };

            foreach (var area in GameData.RogueDLCAreaData.Keys)
            {
                proto.ExploredAreaIdList.Add((uint)area);
            }


            return proto;
        }

        public ChessRogueQueryAeonInfo ToAeonInfo()
        {
            var proto = new ChessRogueQueryAeonInfo();

            foreach (var aeon in GameData.RogueNousAeonData.Values)
            {
                proto.AeonList.Add(new ChessRogueQueryAeon()
                {
                    AeonId = (uint)aeon.AeonID,
                });
            }

            return proto;
        }

        public ChessRogueAeonInfo ToRogueAeonInfo()
        {
            var proto = new ChessRogueAeonInfo()
            {
                AeonInfo = ToAeonInfo(),
            };


            foreach (var aeon in GameData.RogueNousAeonData.Values)
            {
                proto.AeonIdList.Add((uint)aeon.AeonID);
            }

            return proto;
        }

        public ChessRogueQueryDiceInfo ToDiceInfo()
        {
            var proto = new ChessRogueQueryDiceInfo()
            {
                DicePhase = ChessRogueNousDicePhase.PhaseTwo,
            };

            foreach (var branch in GameData.RogueNousDiceSurfaceData.Keys)
            {
                proto.SurfaceIdList.Add((uint)branch);
            }

            foreach (var dice in GameData.RogueNousDiceBranchData)
            {
                proto.DiceList.Add(GetDice(dice.Key).ToProto());
            }

            for (var i = 1; i < 7; i++)
            {
                proto.MBIPCPCFIHL.Add((uint)i, i % 3 == 0);
            }
            proto.MBIPCPCFIHL[5] = true;

            return proto;
        }

        public ChessRogueDiceInfo ToRogueDiceInfo()
        {
            var proto = new ChessRogueDiceInfo()
            {
                IsValid = true,
                LIEILGBCKPI = 10
            };

            return proto;
        }

        public List<ChessRogueGameInfo> ToGameInfo()
        {
            var proto = new List<ChessRogueGameInfo>
            {
                new()
                {
                    RogueAeonInfo = new()
                },
                new()
                {
                    GameItemInfo = new()
                },
                new()
                {
                    GameMiracleInfo = new()
                    {
                        MiracleInfo = new()
                    }
                },
                new()
                {
                    RogueBuffInfo = new()
                    {
                        BuffInfo = new()
                    }
                }
            };

            return proto;
        }

        public ChessRogueTalentInfo ToTalentInfo()
        {
            var talentInfo = new RogueTalentInfo();

            foreach (var talent in GameData.RogueNousTalentData.Values)
            {
                talentInfo.RogueTalent.Add(new RogueTalent()
                {
                    TalentId = (uint)talent.TalentID,
                    Status = RogueTalentStatus.Enable
                });
            }

            var proto = new ChessRogueTalentInfo()
            {
                TalentInfo = talentInfo,
            };

            return proto;
        }

        #endregion
    }
}
