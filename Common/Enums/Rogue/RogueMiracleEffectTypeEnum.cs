using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggLink.DanhengServer.Enums.Rogue
{
    public enum RogueMiracleEffectTypeEnum
    {
        None = 0,
        ExtraBuffSelectReduceNumber = 1,
        ExtraFreeBuffRoll = 2,
        SetSelectBuffLevel = 3,
        ReviveLineupAvatar = 4,
        ExtraBuffRandomCount = 5,
        AddMazeBuffAfterMonsterKill = 6,
        SetSelectBuffGroupCount = 7,
        AddMazeBuff = 8,
        ChangeItemRatio = 9,
        ChangeCostRatio = 10,
        ChangeItemRatioOnNextRoom = 11,
        AddRogueBuffGroupNumber = 12,
        RepairRandomMiracle = 13,
        UpgradeRandomBuff = 14,
        ReplaceAllMiracles = 15,
        SetBattleWinOnBattleFail = 16,
        StartDestructPropExtraMiracle = 17,
        ChangePropDestructNumber = 18,
        StartDestructPropRecord = 19,
        ChangeCurrentItemImmediately = 20,
        ChangeAllRogueAvatarLineupDataByCurrent = 21,
        ChangePropHitResultRatio = 22,
        GetItemWithFullHpCountAfterMonsterKill = 23,
        StartDestructPropExtraBuff = 24,
        AddMiracleFromListOnBattleWin = 25,
        SetIsBattleTriggerNoBuffSelect = 26,
        MultipleItemRatio = 27,
        GetOrRemoveItemOnEnterRoom = 28,
        SetCountByConsumeItem = 29,
        ReplaceAllBuffs = 30,
        AddCurAeonBuffWithRandomCnt = 31,  // minCount, maxCount, aeonId, buffGroup, aeonId, buffGroup, ...
        SetSelectBuffRandomEnhance = 32,
        SelectMazeBuffOnSelectAeon = 33,
        GetItem = 34,
        TurnBlockTypeToTarget = 35,
        AddMazeBuffOnEnterCellWithBlockType = 36,
        SetCountByEnterCellType = 37,
        ChangeRogueShopDiscountRatio = 38,
        GetDiceRollNum = 39,
        ModifyBuffTypeCount = 40,
        ModifyAdventureRoomTime = 41,
        GetRogueCoinWithNotify = 42,
        AccumulateCoinRecord = 43,
        AdventureRoomExtraGroup = 44,
        GetCoinByBlockType = 45,
        SetDiceReRollNum = 46,
        SetDiceReRollFree = 47,
        RoomRepeatedSurfaceUseMiracle = 48,
        RefreshBuffSelectGuaranteedAeonBuff = 49,
        UseMiracleByEnterCellType = 50,
        ModifyDiceSurfaceWeightByRarity = 51,
    }
}
