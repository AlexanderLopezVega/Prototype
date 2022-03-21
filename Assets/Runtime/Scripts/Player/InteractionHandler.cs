using Multiscene.Runtime;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class InteractionHandler : MonoBehaviour, IBootListener
    {
        [Header("Dependencies")]
        [SerializeField] private Transform actorRoot = default;
        [SerializeField] private Transform interactionSource = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float interactionRadius = default;
        [SerializeField] private LayerMask interactionMask = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            IPlayerEvents playerEvents = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            playerEvents.OnInteractActionEvent += OnInteract;
        }

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

        private void OnInteract(CallbackContext ctx)
        {
            if (ctx.performed)
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
