using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private uint maximumWeight = default;

        private Dictionary<Item, ItemStack> itemStackMap = default;
        private float currentWeight = default;

        // Observers
        private ISet<IInventoryObserver> observerSet = default;

        public void Awake()
        {
            itemStackMap = new Dictionary<Item, ItemStack>();
            observerSet = new HashSet<IInventoryObserver>();
        }

        public void AddItem(Item item, uint amount)
        {
            ItemStack currentItemStack = itemStackMap.Emplace(item, new ItemStack() { Item = item, Amount = 0 });
            ItemStack previousItemStack = new ItemStack(currentItemStack);

            currentItemStack.Amount += amount;
            currentWeight += item.Weight * amount;

            NotifyObservers(observer => observer.OnItemAdded(itemStackMap, previousItemStack, currentItemStack));
        }

        public void AddItem(ItemStack itemStack) => AddItem(itemStack.Item, itemStack.Amount);

        public uint RemoveItem(Item item, uint amount)
        {
            if (!itemStackMap.TryGetValue(item, out ItemStack currentItemStack))
                return 0;

            ItemStack previousItemStack = new ItemStack(currentItemStack);

            uint remainder = (currentItemStack.Amount <= amount) ? 0 : currentItemStack.Amount - amount;

            if ((currentItemStack.Amount = remainder) == 0)
                itemStackMap.Remove(item);

            currentWeight -= item.Weight * (previousItemStack.Amount - currentItemStack.Amount);

            NotifyObservers(observer => observer.OnItemRemoved(itemStackMap, previousItemStack, currentItemStack));

            return previousItemStack.Amount - currentItemStack.Amount;
        }

        public uint RemoveItem(ItemStack itemStack) => RemoveItem(itemStack.Item, itemStack.Amount);

        public ItemStack GetStack(Item item) => !itemStackMap.TryGetValue(item, out ItemStack stack) ? default : stack;

        public bool HasEnough(Item item, uint amount) => itemStackMap.TryGetValue(item, out ItemStack stack) && stack.Amount >= amount;
        public bool HasEnough(ItemStack itemStack) => HasEnough(itemStack.Item, itemStack.Amount);

        public bool HasRemainingWeight() => currentWeight < maximumWeight;

        // Observer
        public void AddObserver(IInventoryObserver observer)
        {
            if (observer == null)
                return;

            observerSet.Add(observer);
            observer.OnRegister(itemStackMap);
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
