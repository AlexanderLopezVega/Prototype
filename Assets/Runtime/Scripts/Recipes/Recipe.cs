using com.alexlopezvega.prototype.inventory;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.recipes
{
    [CreateAssetMenu(menuName = AssetMenuCts.Recipe)]
    public class Recipe : ScriptableObject
    {
        [field: SerializeField] public List<Item> RequiredTools { get; private set; }
        [field: SerializeField] public List<ItemStack> Materials { get; private set; }
        [field: SerializeField] public ItemStack Output { get; private set; }
    }
}
