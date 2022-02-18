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
        [SerializeField] private Transform submarineRoot = default;
        [SerializeField] private Rigidbody submarineRigidbody = default;
        [Header("Throttle")]
        [SerializeField, Min(0f)] private float speed = default;
        [SerializeField, Min(0f)] private float throttleRate = default;
        [SerializeField] private float minThrottle = default;
        [SerializeField] private float maxThrottle = default;
        [Header("Throttle")]
        [SerializeField] private float steerSpeed = default;
        [SerializeField, Min(0f)] private float steerRate = default;
        [SerializeField] private float minSteer = default;
        [SerializeField] private float maxSteer = default;
        [Header("Throttle")]
        [SerializeField, Min(0f)] private float ascentSpeed = default;
        [SerializeField, Min(0f)] private float ascentRate = default;
        [SerializeField] private float minAscent = default;
        [SerializeField] private float maxAscent = default;

        // Input
        private float throttleInput = default;
        private float steerInput = default;
        private float ascentInput = default;

        private float throttle = default;
        private float steer = default;
        private float ascent = default;

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

            throttle = Mathf.Clamp(throttle + throttleInput * throttleRate * dt, minThrottle, maxThrottle);
            steer = Mathf.Clamp(steer + steerInput * steerRate * dt, minSteer, maxSteer);
            ascent = Mathf.Clamp(ascent + ascentInput * ascentRate * dt, minAscent, maxAscent);
        }

        private void FixedUpdate()
        {
            float dt = Time.fixedDeltaTime;

            Vector3 translation = (throttle * speed * submarineRoot.forward + ascent * ascentSpeed * Vector3.up) * dt;
            Vector3 rotation = steer * steerSpeed * Vector3.up * dt;

            Quaternion rotationQuaternion = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

            submarineRigidbody.MovePosition(submarineRigidbody.position + translation);
            submarineRigidbody.MoveRotation(submarineRigidbody.rotation * rotationQuaternion);
        }

        private void OnThrottleAction(CallbackContext context) => throttleInput = context.ReadValue<float>();
        private void OnSteerAction(CallbackContext context) => steerInput = context.ReadValue<float>();
        private void OnAscentAction(CallbackContext context) => ascentInput = context.ReadValue<float>();

        // Structs

        // Classes

    }
}
