using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Item)]
    public class Item : InventoryElement
    {
        [field: SerializeField] public string Name { get; private set; } // Name of the item, not the ScriptableObject
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public List<Category> Categories { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: Header("Data")]
        [field: SerializeField, Min(0f)] public float Weight { get; private set; }
        [field: SerializeField, Min(0f)] public float Volume { get; private set; }
    }
}
