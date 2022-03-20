using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class VehiclePassenger : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Rigidbody vehicleRigidbody = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        public void FixedUpdate()
        {
            if (vehicleRigidbody == null)
                return;

            float dt = Time.fixedDeltaTime;

            playerRoot.position += vehicleRigidbody.GetPointVelocity(playerRoot.position) * dt;
            playerRoot.rotation *= Quaternion.Euler(dt * Mathf.Rad2Deg * vehicleRigidbody.angularVelocity);
        }

        // Structs

        // Classes

    }
}
