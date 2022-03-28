using ScriptableObjectData.Runtime.SOData;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    [CreateAssetMenu(menuName = AssetMenuCts.Category)]
    public class Category : ScriptableObject
    {
        [field: SerializeField] public StringReference Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}
