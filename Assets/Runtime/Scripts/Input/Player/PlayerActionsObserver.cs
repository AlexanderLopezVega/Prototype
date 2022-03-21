using System;
using static com.alexlopezvega.prototype.Controls;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerActionsObserver : IPlayerActions, IPlayerEvents
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
        void IPlayerActions.OnMove(CallbackContext context) => OnMoveActionEvent?.Invoke(context);
        void IPlayerActions.OnJump(CallbackContext context) => OnJumpActionEvent?.Invoke(context);
        void IPlayerActions.OnLook(CallbackContext context) => OnLookActionEvent?.Invoke(context);
        void IPlayerActions.OnInteract(CallbackContext context) => OnInteractActionEvent?.Invoke(context);

        void IPlayerActions.OnToggleInventory(CallbackContext context) => OnToggleInventoryActionEvent?.Invoke(context);
        void IPlayerActions.OnToggleCrafting(CallbackContext context) => OnToggleCraftingActionEvent?.Invoke(context);

        // Properties

        // Indexers

        // Methods

        // Structs

        // Classes
    }
}
