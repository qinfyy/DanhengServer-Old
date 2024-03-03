using EggLink.DanhengServer.Database;
using EggLink.DanhengServer.Database.Inventory;
using EggLink.DanhengServer.Game.Player;

namespace EggLink.DanhengServer.Game.Inventory
{
    public class InventoryManager : BasePlayerManager
    {
        public InventoryData Data;
        public InventoryManager(PlayerInstance player) : base(player)
        {
            var inventory = DatabaseHelper.Instance?.GetInstance<InventoryData>(player.Uid);
            if (inventory == null)
            {
                DatabaseHelper.Instance?.SaveInstance(new InventoryData()
                {
                    Uid = player.Uid,
                });
                inventory = DatabaseHelper.Instance?.GetInstance<InventoryData>(player.Uid);
            }
            Data = inventory!;
        }


    }
}
