using com.alexlopezvega.prototype.inventory;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class Prop : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform root = default;
        [SerializeField] private Item inventoryItem = default;

        public void PickUp(Transform actorRoot)
        {
            actorRoot.GetComponent<Inventory>().AddItem(inventoryItem, 1);

            Destroy(root.gameObject);
        }
    }
}
