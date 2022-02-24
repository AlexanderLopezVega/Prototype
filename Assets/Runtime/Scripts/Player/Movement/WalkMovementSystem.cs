using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    [System.Serializable]
    public class WalkMovementSystem : MovementSystem
    {
        // Constant Fields

        // Fields
        [Header("Data")]
        [SerializeField, Min(0f)] private float maximumSpeed = default;
        [SerializeField, Min(0f)] private float jumpHeight = default;

        private Vector3 velocity = default;

        protected Vector2 moveAxisInput = default;
        protected bool jumpPerformedInput = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        public void OnMoveAction(CallbackContext ctx) => moveAxisInput = ctx.ReadValue<Vector2>();
        public void OnJumpAction(CallbackContext ctx) => jumpPerformedInput = ctx.performed;

        private Vector3 CalculateMotion(CharacterController characterController, float dt)
        {
            Transform transform = characterController.transform;

            Vector3 walkMotion = CalculateWalkMotion(dt, transform);
            Vector3 velocityMotion = CalculateVelocityMotion(dt);

            return walkMotion + velocityMotion;
        }

        private Vector3 CalculateWalkDirection(Transform transform)
        {
            Vector3 directionUnclamped = transform.right * moveAxisInput.x + transform.forward * moveAxisInput.y;

            return Vector3.ClampMagnitude(directionUnclamped, 1f);
        }

        private Vector3 CalculateWalkMotion(float dt, Transform transform)
        {
            return maximumSpeed * dt * CalculateWalkDirection(transform);
        }

        private Vector3 CalculateVelocityMotion(float dt)
        {
            return velocity * dt;
        }

        private void HandleJump()
        {
            if (jumpPerformedInput)
                Jump();
        }

        private void HandleVelocity(float dt, CharacterController characterController)
        {
            velocity += Physics.gravity * dt;

            if (characterController.isGrounded)
                velocity.y = 0f;
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(2f * -Physics.gravity.y * jumpHeight);
        }

        public override void OnUpdate(CharacterController characterController, float dt)
        {
            HandleVelocity(dt, characterController);
            HandleJump();

            characterController.Move(CalculateMotion(characterController, dt));
        }

        public override void SubscribeToEvents(IPlayerEvents playerEvents)
        {
            playerEvents.OnMoveActionEvent += OnMoveAction;
            playerEvents.OnJumpActionEvent += OnJumpAction;
        }
        public override void UnsubscribeFromEvents(IPlayerEvents playerEvents)
        {
            playerEvents.OnMoveActionEvent -= OnMoveAction;
            playerEvents.OnJumpActionEvent -= OnJumpAction;
        }

        // Structs

        // Classes

    }
}
