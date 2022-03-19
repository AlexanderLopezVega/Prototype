using System.Collections.Generic;

namespace com.alexlopezvega.prototype.inventory
{
    public interface IInventoryObserver
    {
        void OnRegister(Dictionary<Item, ItemStack> itemMap);
        void OnItemAdded(Item item, uint previousAmount, uint currentAmount);
        void OnItemRemoved(Item item, uint previousAmount, uint currentAmount);
    }
}
