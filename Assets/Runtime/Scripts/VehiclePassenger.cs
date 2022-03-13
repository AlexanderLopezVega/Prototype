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
            float dt = Time.fixedDeltaTime;

            playerRoot.position += vehicleRigidbody.GetPointVelocity(playerRoot.position) * dt;
            playerRoot.rotation *= Quaternion.Euler(vehicleRigidbody.angularVelocity * Mathf.Rad2Deg * dt);
        }

        // Structs

        // Classes

    }
}
