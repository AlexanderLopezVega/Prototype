using com.alexlopezvega.prototype.inventory;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class InventoryWrapper : MonoBehaviour
    {
        [field: SerializeField] public Inventory Inventory { get; private set; }
    }
}
