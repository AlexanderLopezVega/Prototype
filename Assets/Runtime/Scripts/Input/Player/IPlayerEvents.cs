using System;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public interface IPlayerEvents 
    {
        // Constant Fields

        // Fields

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events
        public event Action<CallbackContext> OnMoveActionEvent;
        public event Action<CallbackContext> OnJumpActionEvent;
        public event Action<CallbackContext> OnLookActionEvent;
        public event Action<CallbackContext> OnInteractActionEvent;

        public event Action<CallbackContext> OnToggleInventoryActionEvent;
        public event Action<CallbackContext> OnToggleCraftingActionEvent;

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods

        // Structs

        // Classes

    }
}
