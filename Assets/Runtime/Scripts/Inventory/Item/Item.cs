using com.alexlopezvega.prototype.ui;
using ScriptableObjectData.Runtime.SOData;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [CreateAssetMenu(menuName = AssetMenuCts.Item)]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; } // Name of the item, not the ScriptableObject
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public List<StringReference> Category { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: Header("Data")]
        [field: SerializeField, Min(0f)] public float Weight { get; private set; }
        [field: SerializeField, Min(0f)] public float Volume { get; private set; }

        public HighlightRenderer HighlightRenderer { get => new ItemRenderer(this); }
    }
}
