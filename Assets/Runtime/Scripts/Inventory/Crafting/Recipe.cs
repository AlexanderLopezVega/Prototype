using com.alexlopezvega.prototype.ui;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Recipe)]
    public class Recipe : InventoryElement
    {
        [field: SerializeField] public List<Item> RequiredTools { get; private set; }
        [field: SerializeField] public List<ItemStack> Materials { get; private set; }
        [field: SerializeField] public ItemStack Output { get; private set; }
    }
}
