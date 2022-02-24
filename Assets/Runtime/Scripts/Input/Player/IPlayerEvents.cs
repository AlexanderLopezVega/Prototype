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
        public event Action<CallbackContext> OnAscentActionEvent;

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods

        // Structs

        // Classes

    }
}
