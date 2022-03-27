using Multiscene.Runtime;
using ScriptableObjectData.Runtime.SOData;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerMovement : MonoBehaviour, IBootListener
    {
        private const float GroundedFallSpeed = -0.2f;

        [Header("Dependencies")]
        [SerializeField] private Transform root = default;
        [SerializeField] private CharacterController characterController = default;
        [SerializeField] private GroundedHandler groundedHandler = default;
        [Space]
        [SerializeField] private StringReference inputActionsObserverTag = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float speed = default;
        [SerializeField, Min(0f)] private float jumpHeight = default;

        private Vector2 moveInput = default;

        private Vector3 velocity = default;
        private bool queueJump = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            IPlayerEvents playerEvents = AssetFinder.FindComponent<InputActionsObserver>(inputActionsObserverTag).Player;

            playerEvents.OnMoveActionEvent += OnMove;
            playerEvents.OnJumpActionEvent += OnJump;
        }
        private void OnDestroy()
        {
            if (!AssetFinder.TryFindComponent(inputActionsObserverTag, out InputActionsObserver iao))
                return;

            IPlayerEvents playerEvents = iao.Player;

            playerEvents.OnMoveActionEvent -= OnMove;
            playerEvents.OnJumpActionEvent -= OnJump;
        }

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

        private void OnMove(CallbackContext ctx)
        {
            moveInput = ctx.ReadValue<Vector2>();
        }
        private void OnJump(CallbackContext ctx)
        {
            if (ctx.performed)
                queueJump = true;
        }

    }
}
