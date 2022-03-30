using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerMovement : MonoBehaviour
    {
        private const float GroundedFallSpeed = -0.2f;

        [Header("Dependencies")]
        [SerializeField] private Transform root = default;
        [SerializeField] private CharacterController characterController = default;
        [SerializeField] private GroundedHandler groundedHandler = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float speed = default;
        [SerializeField, Min(0f)] private float jumpHeight = default;

        private Vector2 moveInput = default;

        private Vector3 velocity = default;
        private bool queueJump = default;

        private void Update()
        {
            Vector3 direction = Vector3.ClampMagnitude(root.right * moveInput.x + root.forward * moveInput.y, 1f);

            Vector3 moveMotion = speed * Time.deltaTime * direction;
            Vector3 velocityMotion = velocity * Time.deltaTime;

            Vector3 netMotion = moveMotion + velocityMotion;

            characterController.Move(netMotion);
        }

        private void FixedUpdate()
        {
            velocity += Physics.gravity * Time.fixedDeltaTime;

            if (groundedHandler.IsGrounded)
            {
                if (queueJump)
                {
                    queueJump = false;
                    velocity.y = Mathf.Sqrt(2f * -Physics.gravity.y * jumpHeight);
                }
                else
                    velocity.y = GroundedFallSpeed;
            }
        }

        public void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();
        }
        public void OnJump(InputValue inputValue)
        {
            if (inputValue.isPressed)
                queueJump = true;
        }

    }
}
