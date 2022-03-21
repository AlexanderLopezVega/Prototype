using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerMovement : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Dependencies")]
        [SerializeField] private Transform root = default;
        [SerializeField] private CharacterController characterController = default;
        [SerializeField] private GroundedHandler groundedHandler = default;
        [Header("Data")]
        [SerializeField] private float speed = default;

        private Vector2 moveInput = default;
        private bool jumpInput = default;

        private Vector3 velocity = default;

        // Constructors

        private void Start()
        {
            IPlayerEvents player = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        private void Start()
        {
            SubscribeMovementSystemsToPlayerEvents();
        }

            if (groundedHandler.IsGrounded)
                velocity.y = -0.2f; // Default grounded falling speed (should be small but negative to "stick" to the ground)
        }
        private void Update()
        {
            Vector3 direction = Vector3.ClampMagnitude(root.right * moveInput.x + root.forward * moveInput.y, 1f);

            Vector3 moveMotion = direction * speed * Time.deltaTime;
            Vector3 velocityMotion = velocity * Time.deltaTime;

            Vector3 netMotion = moveMotion + velocityMotion;

            characterController.Move(netMotion);
        }

        private void FixedUpdate()
        {
            velocity += Physics.gravity * Time.fixedDeltaTime;
        }

        private void Jump()
        {
            IPlayerEvents events = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            events.OnMoveActionEvent += OnMove;
            events.OnJumpActionEvent += OnJump;
        }

        private void OnMoveAction(CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();
        private void OnJumpAction(CallbackContext ctx)
        {
            if (AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver iao))
            {
                IPlayerEvents events = iao.Player;

                events.OnMoveActionEvent -= OnMove;
                events.OnJumpActionEvent -= OnJump;
            }
        }

        private void OnMove(CallbackContext ctx)
        {
            moveInput = ctx.ReadValue<Vector2>();
        }
        private void OnJump(CallbackContext ctx)
        {
            if(ctx.performed)
                jumpInput = true;
        }

        // Structs

        // Classes

    }
}
