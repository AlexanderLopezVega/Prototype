using com.alexlopezvega.prototype.ui;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private uint capacity = default;
        [SerializeField] private List<Item> items = default;

        private Dictionary<Item, ItemStack> itemStackSet = default;

        // Observers
        private ISet<IInventoryObserver> observerSet = default;

        public void Awake()
        {
            itemStackSet = new Dictionary<Item, ItemStack>();
            observerSet = new HashSet<IInventoryObserver>();

            foreach (Item item in items)
                AddItem(item, 1);
        }

        public bool AddItem(Item item, uint amount)
        {
            uint previousAmount = 0;
            uint currentAmount = 0;

            if (!itemStackSet.ContainsKey(item))
            {
                if (!HasRemainingCapacity())
                    return false;
                else
                    itemStackSet[item] = new ItemStack(item, amount);
            }
            else
            {
                previousAmount = itemStackSet[item].amount;
                itemStackSet[item].amount += amount;
            }

            currentAmount = itemStackSet[item].amount;

            NotifyObservers(observer => observer.OnItemAdded(item, previousAmount, currentAmount));

            return true;
        }

        public bool AddItem(ItemStack itemStack) => AddItem(itemStack.item, itemStack.amount);

        public uint RemoveItem(Item item, uint amount)
        {
            if (!itemStackSet.ContainsKey(item))
                return 0;

            uint previousAmount = itemStackSet[item].amount;
            uint currentAmount = 0;

            if (previousAmount <= amount)
                itemStackSet.Remove(item);
            else
            {
                itemStackSet[item].amount -= amount;

                currentAmount = itemStackSet[item].amount;
            }

            NotifyObservers(observer => observer.OnItemRemoved(item, previousAmount, currentAmount));

            return previousAmount - currentAmount;
        }

        public uint RemoveItem(ItemStack itemStack) => RemoveItem(itemStack.item, itemStack.amount);

        public ItemStack GetStack(Item item) => !itemStackSet.ContainsKey(item) ? default : itemStackSet[item];

        public bool HasEnough(Item item, uint amount) => itemStackSet.ContainsKey(item) && itemStackSet[item].amount >= amount;
        public bool HasEnough(ItemStack itemStack) => HasEnough(itemStack.item, itemStack.amount);

        private bool HasRemainingCapacity() => itemStackSet.Keys.Count < capacity;

        // Observer

        public void AddObserver(IInventoryObserver observer)
        {
            if (observer == null)
                return;

            observerSet.Add(observer);
            observer.OnRegister(itemStackSet);
        }
        public void RemoveObserver(IInventoryObserver observer)
        {
            if (observer == null)
                return;

            observerSet.Remove(observer);
        }

        private void NotifyObservers(Action<IInventoryObserver> observerAction)
        {
            foreach (var observer in observerSet)
                observerAction(observer);
        }
    }
}
