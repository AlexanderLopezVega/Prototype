using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    [System.Serializable]
    public class SwimMovementSystem : MovementSystem
    {
        // Constant Fields

        // Fields
        [Header("Data")]
        [SerializeField, Min(0f)] private float maximumSwimSpeed = default;
        [SerializeField, Min(0f)] private float acceleration = default;

        private Vector3 velocity = default;

        protected Vector2 moveAxisInput = default;
        protected float ascentAxisInput = default;

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
        public void OnAscentAction(CallbackContext ctx) => ascentAxisInput = ctx.ReadValue<float>();

        private Vector3 CalculateSwimDirection(Transform transform)
        {
            Vector3 directionUnclamped = transform.right * moveAxisInput.x + transform.forward * moveAxisInput.y + transform.up * ascentAxisInput;

            return Vector3.ClampMagnitude(directionUnclamped, 1f);
        }

        private Vector3 CalculateSwimMotion(float dt)
        {
            return maximumSwimSpeed * dt * velocity;
        }

        private void HandleAcceleration(Transform transform, float dt)
        {
            Vector3 targetVelocity = maximumSwimSpeed * CalculateSwimDirection(transform);

            velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * dt);
        }

        public override void OnUpdate(CharacterController characterController, float dt)
        {
            HandleAcceleration(characterController.transform, dt);

            characterController.Move(CalculateSwimMotion(dt));
        }

        public override void SubscribeToEvents(IPlayerEvents playerEvents)
        {
            playerEvents.OnMoveActionEvent += OnMoveAction;
        }
        public override void UnsubscribeFromEvents(IPlayerEvents playerEvents)
        {
            playerEvents.OnMoveActionEvent -= OnMoveAction;
        }

        // Structs

        // Classes

    }
}
