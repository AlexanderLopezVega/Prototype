using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class SubmarinePassenger : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Rigidbody submarineRigidbody = default;

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

            playerRoot.position += submarineRigidbody.GetPointVelocity(playerRoot.position) * dt;
            playerRoot.rotation *= Quaternion.Euler(submarineRigidbody.angularVelocity * Mathf.Rad2Deg * dt);
        }

        // Structs

        // Classes

    }
}
