using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private uint capacity = default;

        private Dictionary<Item, uint> itemStackSet = default;

        public void Start()
        {
            itemStackSet = new Dictionary<Item, uint>();
        }

        public bool AddItem(Item item, uint amount)
        {
            if (!itemStackSet.ContainsKey(item))
            {
                if (!HasRemainingCapacity())
                    return false;
                else
                    itemStackSet[item] = amount;
            }
            else
                itemStackSet[item] += amount;

            return true;
        }

        public uint RemoveItem(Item item, uint amount)
        {
            if (!itemStackSet.ContainsKey(item))
                return 0;

            uint currentAmount = itemStackSet[item];

            if (currentAmount <= amount)
            {
                itemStackSet.Remove(item);

                return currentAmount;
            }
            else
            {
                itemStackSet[item] -= amount;

                return amount;
            }
        }

        public uint GetAmount(Item item) => !itemStackSet.ContainsKey(item) ? 0 : itemStackSet[item];

        private bool HasRemainingCapacity() => itemStackSet.Keys.Count < capacity;
    }
}
