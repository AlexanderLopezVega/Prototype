using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class InteractionHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform actorRoot = default;
        [SerializeField] private Transform interactionSource = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float interactionRadius = default;
        [SerializeField] private LayerMask interactionMask = default;

        public void TryInteract()
        {
            Collider[] affectedColliders = Physics.OverlapSphere(interactionSource.position, interactionRadius, interactionMask);

            foreach (var collider in affectedColliders)
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact(actorRoot);
                    return;
                }
        }

        public void OnInteract(InputValue inputValue)
        {
            if (inputValue.isPressed)
                TryInteract();
        }

        private void OnDrawGizmosSelected()
        {
            if (interactionSource == null)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactionSource.position, interactionRadius);
        }
    }
}
