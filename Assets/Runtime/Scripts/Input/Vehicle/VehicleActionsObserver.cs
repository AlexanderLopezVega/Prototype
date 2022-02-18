using System;
using static com.alexlopezvega.prototype.Controls;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class VehicleActionsObserver : IVehicleActions, IVehicleEvents
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
        public void OnThrottle(CallbackContext context) => OnThrottleActionEvent?.Invoke(context);
        public void OnSteering(CallbackContext context) => OnSteerActionEvent?.Invoke(context);
        public void OnAscent(CallbackContext context) => OnAscentActionEvent?.Invoke(context);


        // Properties

        // Indexers

        // Methods

        // Structs

        // Classes
    }
}
