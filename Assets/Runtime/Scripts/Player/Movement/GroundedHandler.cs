using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class GroundedHandler : MonoBehaviour
    {
        [SerializeField] private Transform groundedHandlerRoot = default;
        [SerializeField, Min(0f)] private float radius = default;
        [SerializeField] private LayerMask layerMask = default;

        public bool IsGrounded { get; private set; }

        private void FixedUpdate() => IsGrounded = Physics.CheckSphere(groundedHandlerRoot.position, radius, layerMask);

        private void OnDrawGizmosSelected()
        {
            if (groundedHandlerRoot == null)
                return;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(groundedHandlerRoot.position, radius);
        }
    }
}
