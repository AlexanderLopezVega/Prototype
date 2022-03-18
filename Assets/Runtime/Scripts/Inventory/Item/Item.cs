using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Item)]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
