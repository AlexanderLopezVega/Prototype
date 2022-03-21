using UnityEngine;
using UnityEngine.Events;

namespace com.alexlopezvega.prototype
{
    public class Interactable : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private UnityEvent<Transform> onInteractionEvent = default;

        public void Interact(Transform sender) => onInteractionEvent.Invoke(sender);
    }
}
