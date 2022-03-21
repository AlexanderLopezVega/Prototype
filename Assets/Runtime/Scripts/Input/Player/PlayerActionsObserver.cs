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

        // Enums

        // Interfaces (interface implementations)
        public void OnMove(CallbackContext context) => OnMoveActionEvent?.Invoke(context);
        public void OnJump(CallbackContext context) => OnJumpActionEvent?.Invoke(context);
        public void OnLook(CallbackContext context) => OnLookActionEvent?.Invoke(context);

        // Properties

        // Indexers

        // Methods

        // Structs

        // Classes
    }
}
