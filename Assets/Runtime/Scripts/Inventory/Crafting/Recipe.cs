using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Recipe)]
    public class Recipe : ScriptableObject
    {
        [field: SerializeField] public List<ItemStack> Inputs { get; private set; }
        [field: SerializeField] public ItemStack Output { get; private set; }
    }
}
