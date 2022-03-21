using com.alexlopezvega.prototype.inventory;
using Multiscene.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.ui
{
    public class InventoryPanel : MonoBehaviour, IBootListener, IInventoryObserver
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform panelRoot = default;

        private Inventory inventory = default;
        private List<ItemSlot> itemSlotList = default;

        public void OnSceneCollectionLoaded()
        {
            AssetFinder.TryFindComponent(TagCts.Player, out inventory);

            FetchAllItemSlots();
            inventory.AddObserver(this);
        }

        public void OnItemAdded(Item item, uint previousAmount, uint currentAmount)
        {
            Debug.Log($"{currentAmount - previousAmount} x {item.Name} added!");
        }

        public void OnItemRemoved(Item item, uint previousAmount, uint currentAmount)
        {

        }

        public void OnRegister(Dictionary<Item, ItemStack> itemMap)
        {
            FillItems(itemMap.Values);
        }

        private void FetchAllItemSlots()
        {
            itemSlotList = new List<ItemSlot>();

            foreach (Transform child in panelRoot)
                itemSlotList.Add(child.GetComponent<ItemSlot>());
        }

        private void FillItems(IEnumerable<ItemStack> stacks)
        {
            int i = 0;

            foreach(var itemStack in stacks)
                itemSlotList[i++].SetItemStack(itemStack);
        }
    }
}
