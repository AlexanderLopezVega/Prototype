using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerMovement : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Dependencies")]
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private CharacterController characterController = default;
        [SerializeField] private GroundedHandler groundedHandler = default;
        [Header("Data")]
        [SerializeField] private Rigidbody frameOfReference = default;
        [SerializeField, Min(0f)] private float walkSpeed = default;
        [SerializeField, Min(0f)] private float runSpeed = default;
        [SerializeField, Min(0f)] private float jumpHeight = default;

        private Vector2 moveInput = default;

        private Vector3 velocity = default;

        private void Start()
        {
            IPlayerEvents player = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            player.OnMoveActionEvent += OnMoveAction;
            player.OnJumpActionEvent += OnJumpAction;
        }
        private void OnDestroy()
        {
            if (AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver iao))
            {
                IPlayerEvents player = iao.Player;

                player.OnMoveActionEvent -= OnMoveAction;
                player.OnJumpActionEvent -= OnJumpAction;
            }
        }

        private void FixedUpdate()
        {
            velocity += Physics.gravity * Time.fixedDeltaTime;

            if (groundedHandler.IsGrounded)
                velocity.y = -0.2f; // Default grounded falling speed (should be small but negative to "stick" to the ground)
        }
        private void Update()
        {
            float dt = Time.deltaTime;

            Vector3 inputDirection = Vector3.ClampMagnitude(playerRoot.right * moveInput.x + playerRoot.forward * moveInput.y, 1f);

            Vector3 moveMotion = dt * walkSpeed * inputDirection;
            Vector3 velocityMotion = velocity * dt;
            Vector3 frameOfReferenceMotion = (frameOfReference != null) ? frameOfReference.GetPointVelocity(playerRoot.position) * dt : Vector3.zero;

            Vector3 combinedMotion = /*moveMotion +*/ velocityMotion + frameOfReferenceMotion;

            characterController.Move(combinedMotion);
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(2f * -Physics.gravity.y * jumpHeight);
        }

        private void OnMoveAction(CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();
        private void OnJumpAction(CallbackContext ctx)
        {
            if (ctx.performed)
                TryJump();
        }

        private void TryJump()
        {
            if (groundedHandler.IsGrounded)
                Jump();
        }
    }
}
