using com.alexlopezvega.prototype.inventory;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class Prop : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform root = default;
        [SerializeField] private Item item = default;

        public void PickUp(Transform actorRoot)
        {
            actorRoot.GetComponent<Inventory>().AddItem(item, 1);

            Destroy(root.gameObject);
        }
    }
}
