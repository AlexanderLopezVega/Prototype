using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class MovementController : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [SerializeField] private Vector2 moveInput = default;

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

        private void OnMoveAction(CallbackContext ctx) => moveInput = ctx.ReadValue<Vector2>();

        // Structs

        // Classes

    }
}
