using com.alexlopezvega.prototype.inventory;
using Multiscene.Runtime;
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
        private Dictionary<Item, ItemStack> itemStackMap = default;

        public void OnSceneCollectionLoaded()
        {
            AssetFinder.TryFindComponent(TagCts.Player, out inventory);

            FetchAllItemSlots();
            inventory.AddObserver(this);
        }

        public void OnRegister(in Dictionary<Item, ItemStack> itemStackMap) => UpdateUI(itemStackMap.Values);
        public void OnItemAdded(in Dictionary<Item, ItemStack> itemMap, in ItemStack previousStack, in ItemStack currentStack) => UpdateUI(itemMap.Values);
        public void OnItemRemoved(in Dictionary<Item, ItemStack> itemMap, in ItemStack previousStack, in ItemStack currentStack) => UpdateUI(itemMap.Values);

        private void ClearItemStacks()
        {
            foreach (var itemSlot in itemSlotList)
                itemSlot.ItemStack = null;
        }

        private void FetchAllItemSlots()
        {
            itemSlotList = new List<ItemSlot>();

            foreach (Transform child in panelRoot)
                itemSlotList.Add(child.GetComponent<ItemSlot>());
        }

        private void FillItems(IEnumerable<ItemStack> stacks)
        {
            int index = 0;
            IEnumerator<ItemStack> itemStackEnumerator = stacks.GetEnumerator();
            bool existsRemainingInventoryStacks;

            CheckRemainingInventoryStacks();

            while(index < itemSlotList.Count && existsRemainingInventoryStacks)
            {
                ItemSlot itemSlot = itemSlotList[index];

                if (itemSlot.ItemStack == null)
                {
                    itemSlot.ItemStack = itemStackEnumerator.Current;
                    CheckRemainingInventoryStacks();
                }

                ++index;
            }

            void CheckRemainingInventoryStacks()
            {
                existsRemainingInventoryStacks = itemStackEnumerator.MoveNext();
            }
        }

        private void UpdateUI(in IEnumerable<ItemStack> itemStacks)
        {
            ClearItemStacks();
            FillItems(itemStacks);
        }
    }
}
