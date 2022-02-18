using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class SubmarineController : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Depdendencies")]
        [SerializeField] private Rigidbody submarineRigidbody = default;

        private float throttleInput = default;
        private float steerInput = default;
        private float ascentInput = default;

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

            inputActionsObserver.Vehicle.OnThrottleActionEvent += OnThrottleAction;
            inputActionsObserver.Vehicle.OnSteerActionEvent += OnSteerAction;
            inputActionsObserver.Vehicle.OnAscentActionEvent += OnAscentAction;
        }
        private void OnDestroy()
        {
            if(AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver inputActionsObserver))
            {
                inputActionsObserver.Vehicle.OnThrottleActionEvent -= OnThrottleAction;
                inputActionsObserver.Vehicle.OnSteerActionEvent -= OnSteerAction;
                inputActionsObserver.Vehicle.OnAscentActionEvent -= OnAscentAction;
            }
        }

        private void OnThrottleAction(CallbackContext context) => throttleInput = context.ReadValue<float>();
        private void OnSteerAction(CallbackContext context) => steerInput = context.ReadValue<float>();
        private void OnAscentAction(CallbackContext context) => ascentInput = context.ReadValue<float>();

        // Structs

        // Classes

    }
}
