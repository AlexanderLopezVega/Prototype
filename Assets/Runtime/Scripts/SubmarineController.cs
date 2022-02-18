using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class SubmarineController : MonoBehaviour
    {
        // Constant Fields
        private const float WaterDensity = 1000f;

        // Fields
        [Header("Depdendencies")]
        [SerializeField] private Rigidbody submarineRigidbody = default;
        [Header("Data")]
        [SerializeField, Min(0f)] private float totalNonHullVolume = default;
        [SerializeField, Min(0f)] private float totalHullEmptyVolume = default;
        [SerializeField, Min(0f)] private float fillSpeed = 1f;

        // Input
        private float throttleInput = default;
        private float steerInput = default;
        private float ascentInput = default;

        // Physics
        private float fillAmount = 0.5f;

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
            if (AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver inputActionsObserver))
            {
                inputActionsObserver.Vehicle.OnThrottleActionEvent -= OnThrottleAction;
                inputActionsObserver.Vehicle.OnSteerActionEvent -= OnSteerAction;
                inputActionsObserver.Vehicle.OnAscentActionEvent -= OnAscentAction;
            }
        }

        private void Update()
        {
            float dt = Time.deltaTime;

            fillAmount = Mathf.Clamp01(Mathf.MoveTowards(fillAmount, fillAmount + ascentInput, (fillSpeed / totalHullEmptyVolume) * dt));
        }

        private void FixedUpdate()
        {
            Vector3 nonHullForce = CalculateBuoyantForce(totalNonHullVolume);
            Vector3 hullForce = CalculateBuoyantForce((1f - fillAmount) * totalHullEmptyVolume);

            submarineRigidbody.AddForce(hullForce + nonHullForce, ForceMode.Force);
        }

        private static Vector3 CalculateBuoyantForce(float volume) => WaterDensity * volume * -Physics.gravity;

        private void OnThrottleAction(CallbackContext context) => throttleInput = context.ReadValue<float>();
        private void OnSteerAction(CallbackContext context) => steerInput = context.ReadValue<float>();
        private void OnAscentAction(CallbackContext context) => ascentInput = context.ReadValue<float>();

        // Structs

        // Classes

    }
}
