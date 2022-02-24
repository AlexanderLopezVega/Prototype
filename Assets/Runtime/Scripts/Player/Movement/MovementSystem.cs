using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    [System.Serializable]
    public abstract class MovementSystem
    {
        // Constant Fields

        // Fields
        private bool enabled = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties
        public bool Enabled
        {
            get => enabled;
            set
            {
                if (value == enabled)
                    return;

                enabled = value;

                if (enabled)
                    OnEnable();
                else
                    OnDisable();
            }
        }

        // Indexers

        // Methods
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }

        public virtual void OnUpdate(CharacterController characterController, float dt) { }

        public abstract void SubscribeToEvents(IPlayerEvents playerEvents);
        public abstract void UnsubscribeFromEvents(IPlayerEvents playerEvents);

        // Structs

        // Classes

    }
}
