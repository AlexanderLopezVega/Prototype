using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class OmniballMovementController : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Dependencies")]
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Rigidbody omniballRigidbody = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float accelerationMagnitude = default;

        private Vector2 moveInput = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        private void Start()
        {
            InputActionsObserver inputActionsObserver = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver);

            inputActionsObserver.Player.OnMoveActionEvent += OnMoveAction;
        }

        private void FixedUpdate()
        {
            Vector3 worldTargetDirection = Vector3.ClampMagnitude(playerRoot.right * moveInput.x + playerRoot.forward * moveInput.y, 1f);
            
            if(worldTargetDirection == Vector3.zero)
                worldTargetDirection = -omniballRigidbody.velocity;
            
            Vector3 worldTorqueDirection = Vector3.Cross(playerRoot.up, worldTargetDirection);

            omniballRigidbody.AddTorque(accelerationMagnitude * worldTorqueDirection, ForceMode.Acceleration);
        }

        private void OnMoveAction(CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();

        // Structs

        // Classes

    }
}
