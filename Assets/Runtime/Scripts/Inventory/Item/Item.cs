using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Item)]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; } // Name of the item, not the ScriptableObject
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
