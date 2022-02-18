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

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        public void OnMove(CallbackContext context) => OnMoveActionEvent?.Invoke(context);

        // Structs

        // Classes
    }
}
