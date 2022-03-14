using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory
    {
        private const string PositiveNonZeroAmountMessage = "Amount must be a positive non-zero integer";

        private Dictionary<Item, int> inventoryItemMap = default;
        private int capacity = default;

        public Inventory(int capacity)
        {
            inventoryItemMap = new Dictionary<Item, int>();
            this.capacity = capacity;
        }

        public bool AddItem(Item item, int amount)
        {
            if (amount < 0)
                throw new InventoryException(PositiveNonZeroAmountMessage);

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

        public int RemoveItem(Item item, int amount)
        {
            if (amount < 0)
                throw new InventoryException(PositiveNonZeroAmountMessage);

            if (!inventoryItemMap.ContainsKey(item))
                return -1;

            int currentAmount = inventoryItemMap[item];
            int removedAmount = Mathf.Min(amount, currentAmount);

            inventoryItemMap[item] -= removedAmount;

            if (removedAmount == 0)
                inventoryItemMap.Remove(item);

            return removedAmount;
        }

        public int GetAmount(Item item) => !inventoryItemMap.ContainsKey(item) ? 0 : inventoryItemMap[item];

        private bool HasRemainingCapacity() => inventoryItemMap.Keys.Count < capacity;
    }
}
