using ScriptableObjectData.Runtime.SOData;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype.vehicle
{
    public class VehicleController : MonoBehaviour
    {
        private const float GizmosCOMRadius = 0.5f;

        [Header("Dependencies")]
        [SerializeField] private Transform vehicleRoot = default;
        [SerializeField] private Rigidbody vehicleRigidbody = default;
        [SerializeField] private List<WheelCollider> motorWheels = default;
        [SerializeField] private List<WheelCollider> steerWheels = default;
        [Space]
        [SerializeField] private StringReference inputActionsObserverTag = default;
        [Header("Data")]
        [SerializeField] private Vector3 localCentreOfMass = default;
        [Header("Motor")]
        [SerializeField, Min(0f)] private float maxSpeed = default;
        [SerializeField, Min(0f)] private float maxWheelTorque = default;
        [Header("Throttle")]
        [SerializeField] private Control throttleControl = default;
        [SerializeField] private Control steerControl = default;

        private bool autorun = default;

        public bool Autorun
        {
            get => autorun;
            private set
            {
                autorun = value;

                OnAutorunChanged(value);
            }
        }

        private void Start()
        {
            InputActionsObserver inputActionsObserver = AssetFinder.FindComponent<InputActionsObserver>(inputActionsObserverTag);

            inputActionsObserver.Vehicle.OnThrottleActionEvent += OnThrottleAction;
            inputActionsObserver.Vehicle.OnSteerActionEvent += OnSteerAction;
            inputActionsObserver.Vehicle.OnAutorunActionEvent += OnAutorunAction;

            UpdateCentreOfMass();
        }
        private void OnDestroy()
        {
            if (AssetFinder.TryFindComponent(inputActionsObserverTag, out InputActionsObserver inputActionsObserver))
            {
                inputActionsObserver.Vehicle.OnThrottleActionEvent -= OnThrottleAction;
                inputActionsObserver.Vehicle.OnSteerActionEvent -= OnSteerAction;
                inputActionsObserver.Vehicle.OnAutorunActionEvent -= OnAutorunAction;
            }
        }

        private void Update()
        {
            float dt = Time.deltaTime;

            throttleControl.Update(dt);
            steerControl.Update(dt);
        }
        private void FixedUpdate()
        {
            float motorTorque = (vehicleRigidbody.velocity.magnitude < maxSpeed) ? throttleControl.Output * maxWheelTorque : 0f;
            float steerAngle = steerControl.Output;

            foreach (var wheel in motorWheels)
                wheel.motorTorque = motorTorque;

            foreach (var wheel in steerWheels)
                wheel.steerAngle = steerAngle * (ShouldInvertSteer(wheel) ? -1f : 1f);
        }

        private void OnDrawGizmosSelected()
        {
            if (vehicleRoot == default)
                return;

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(vehicleRoot.TransformPoint(localCentreOfMass), GizmosCOMRadius);
        }

        private void OnValidate()
        {
            UpdateCentreOfMass();
        }

        private void OnAutorunChanged(bool autorunEnabled)
        {
            if (autorunEnabled)
                throttleControl.NormalisedTarget = throttleControl.NormalisedOutput;
        }

        private void OnThrottleAction(CallbackContext context)
        {
            if (Autorun && context.canceled)
                return;

            throttleControl.NormalisedTarget = context.ReadValue<float>();
            Autorun = false;
        }
        private void OnSteerAction(CallbackContext context) => steerControl.NormalisedTarget = context.ReadValue<float>();
        private void OnAutorunAction(CallbackContext context)
        {
            if (context.performed)
                Autorun = !Autorun;
        }

        private bool ShouldInvertSteer(WheelCollider wheel)
        {
            Vector3 toWheelDir = wheel.transform.position - vehicleRoot.position;

            return Mathf.Abs(Vector3.Angle(toWheelDir, vehicleRoot.forward)) > 90f;
        }

        private void UpdateCentreOfMass()
        {
            vehicleRigidbody.centerOfMass = localCentreOfMass;
        }
    }
}
