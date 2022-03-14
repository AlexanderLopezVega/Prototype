using System.Collections.Generic;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory
    {
        private readonly Dictionary<Item, uint> inventoryItemMap = default;
        private readonly uint capacity = default;

        public Inventory(uint capacity)
        {
            inventoryItemMap = new Dictionary<Item, uint>();
            this.capacity = capacity;
        }

        public bool AddItem(Item item, uint amount)
        {
            if (!inventoryItemMap.ContainsKey(item))
            {
                if (!HasRemainingCapacity())
                    return false;
                else
                    inventoryItemMap[item] = amount;
            }
            else
                inventoryItemMap[item] += amount;

            return true;
        }

        public uint RemoveItem(Item item, uint amount)
        {
            if (!inventoryItemMap.ContainsKey(item))
                return 0;

            uint currentAmount = inventoryItemMap[item];
            
            if(currentAmount <= amount)
            {
                inventoryItemMap.Remove(item);

                return currentAmount;
            }
            else
            {
                inventoryItemMap[item] -= amount;

                return amount;
            }
        }

        public uint GetAmount(Item item) => !inventoryItemMap.ContainsKey(item) ? 0 : inventoryItemMap[item];

        private bool HasRemainingCapacity() => inventoryItemMap.Keys.Count < capacity;
    }
}
