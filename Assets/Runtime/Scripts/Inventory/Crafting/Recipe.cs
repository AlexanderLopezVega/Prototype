using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Recipe)]
    public class Recipe : ScriptableObject
    {
        [field: SerializeField] public string RecipeName { get; private set; }
        [Space]
        [SerializeField] private List<ItemStack> inputs = default;
        [SerializeField] private List<ItemStack> outputs = default;
    }
}
