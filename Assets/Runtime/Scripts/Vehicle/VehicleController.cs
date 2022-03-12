using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class VehicleController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform vehicleRoot = default;
        [SerializeField] private List<WheelCollider> wheels = default;
        [Header("Data")]
        [Header("Motor")]
        [SerializeField, Min(0f)] private float maxReverseWheelMotorTorque = default;
        [SerializeField, Min(0f)] private float maxWheelMotorTorque = default;
        [SerializeField] private float motorAcceleration = default;
        [Header("Steer")]
        [SerializeField, Min(0f)] private float maxSteerAngle = default;
        [SerializeField, Min(0f)] private float steerAcceleration = default;

        // Input
        private float throttleInput = default;
        private float steerInput = default;

        private float currentMotorTorque = default;
        private float currentSteerAngle = default;

        private void Start()
        {
            InputActionsObserver inputActionsObserver = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver);

            inputActionsObserver.Vehicle.OnThrottleActionEvent += OnThrottleAction;
            inputActionsObserver.Vehicle.OnSteerActionEvent += OnSteerAction;
        }
        private void OnDestroy()
        {
            if (AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver inputActionsObserver))
            {
                inputActionsObserver.Vehicle.OnThrottleActionEvent -= OnThrottleAction;
                inputActionsObserver.Vehicle.OnSteerActionEvent -= OnSteerAction;
            }
        }

        private void Update()
        {
            float newMotorTorque = currentMotorTorque + motorAcceleration * throttleInput * Time.deltaTime;
            float newSteerAngle = currentSteerAngle + steerAcceleration * steerInput * Time.deltaTime;

            currentMotorTorque = Mathf.Clamp(newMotorTorque, -maxReverseWheelMotorTorque, maxWheelMotorTorque);
            currentSteerAngle = Mathf.Clamp(newSteerAngle, -maxSteerAngle, maxSteerAngle);
        }
        private void FixedUpdate()
        {
            foreach (var wheel in wheels)
            {
                Vector3 toWheelDir = wheel.transform.position - vehicleRoot.position;

                float angle = Vector3.Angle(toWheelDir, vehicleRoot.forward);
                bool invertWheel = Mathf.Abs(angle) > 90f;

                wheel.motorTorque = currentMotorTorque;
                wheel.steerAngle = currentSteerAngle * (invertWheel ? -1f : 1f);
            }
        }

        private void OnThrottleAction(CallbackContext context) => throttleInput = context.ReadValue<float>();
        private void OnSteerAction(CallbackContext context) => steerInput = context.ReadValue<float>();
    }
}
