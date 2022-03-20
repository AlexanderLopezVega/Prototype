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

        public void OnSceneCollectionLoaded()
        {
            AssetFinder.TryFindComponent(TagCts.Player, out inventory);

            inventory.AddObserver(this);
        }

        public void OnItemAdded(Item item, uint previousAmount, uint currentAmount)
        {

        }

        public void OnItemRemoved(Item item, uint previousAmount, uint currentAmount)
        {

        }

        public void OnRegister(Dictionary<Item, ItemStack> itemMap)
        {
            foreach(var itemStack in itemMap.Values)
            {

            }
        }
    }
}
