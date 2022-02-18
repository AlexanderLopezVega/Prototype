using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class VehiclePassenger : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Dependencies")]
        [SerializeField] private SubmarineController submarineController = default;
        [SerializeField] private Rigidbody passengerRigidbody = default;

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
            submarineController.OnPositionChangedEvent += OnPositionChanged;
            submarineController.OnRotationChangedEvent += OnRotationChanged;
        }

        private void OnPositionChanged(Vector3 previousPosition, Vector3 currentPosition, Vector3 translationMotion)
        {
            passengerRigidbody.MovePosition(passengerRigidbody.position + translationMotion);
        }
        private void OnRotationChanged(Quaternion previousRotation, Quaternion currentRotation, Quaternion rotationMotion)
        {
            passengerRigidbody.MoveRotation(passengerRigidbody.rotation * rotationMotion);
        }

        // Structs

        // Classes

    }
}
