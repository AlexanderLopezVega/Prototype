using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private uint maximumWeight = default;

        private Dictionary<Item, ItemStack> itemStackSet = default;
        private uint currentWeight = default;

        // Observers
        private ISet<IInventoryObserver> observerSet = default;

        public void Awake()
        {
            itemStackSet = new Dictionary<Item, ItemStack>();
            observerSet = new HashSet<IInventoryObserver>();
        }

        public void AddItem(Item item, uint amount)
        {
            ItemStack itemStack = itemStackSet.Emplace(item);

            uint previousAmount = itemStack.Amount;
            itemStack.Amount += amount;
            uint currentAmount = itemStack.Amount;

            currentWeight += item.Weight * amount;

            NotifyObservers(observer => observer.OnItemAdded(item, previousAmount, 0));
        }

        public void AddItem(ItemStack itemStack) => AddItem(itemStack.Item, itemStack.Amount);

        public uint RemoveItem(Item item, uint amount)
        {
            if (!itemStackSet.TryGetValue(item, out ItemStack value))
                return 0;

            uint remainder = (value.Amount <= amount) ? 0 : value.Amount - amount;

            uint previousAmount = value.Amount;
            value.Amount = remainder;
            uint currentAmount = value.Amount;

            if (value.Amount == 0)
                itemStackSet.Remove(item);

            currentWeight -= item.Weight * (previousAmount - currentAmount);

            NotifyObservers(observer => observer.OnItemRemoved(item, previousAmount, currentAmount));

            return previousAmount - currentAmount;
        }

        public uint RemoveItem(ItemStack itemStack) => RemoveItem(itemStack.Item, itemStack.Amount);

        public ItemStack GetStack(Item item) => !itemStackSet.TryGetValue(item, out ItemStack stack) ? default : stack;

        public bool HasEnough(Item item, uint amount) => itemStackSet.TryGetValue(item, out ItemStack stack) && stack.Amount >= amount;
        public bool HasEnough(ItemStack itemStack) => HasEnough(itemStack.Item, itemStack.Amount);

        public bool HasRemainingWeight() => currentWeight < maximumWeight;

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
