using System;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public interface IVehicleEvents
    {
        // Constant Fields

        // Fields

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events
        public event Action<CallbackContext> OnThrottleActionEvent;
        public event Action<CallbackContext> OnSteerActionEvent;
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
