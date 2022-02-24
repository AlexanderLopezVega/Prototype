using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class PlayerMovement : MonoBehaviour
    {
        // Constant Fields

        // Fields
        [Header("Dependencies")]
        [SerializeField] private CharacterController characterController = default;
        [Header("Data")]
        [SerializeField] private MovementSystemTypes defaultMovementSystem = default;
        [SerializeField] private WalkMovementSystem walkMovementSystem = default;
        [SerializeField] private SwimMovementSystem swimMovementSystem = default;

        private MovementSystem activeMovementSystem = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties
        private MovementSystem Active
        {
            get => activeMovementSystem;
            set
            {
                if (Active == value)
                    return;

                SetAllEnabled(false);

                activeMovementSystem = value;
                activeMovementSystem.Enabled = true;
            }
        }

        // Indexers

        // Methods
        private void Start()
        {
            SetDefaultMovementSystem();
            SubscribeMovementSystemsToPlayerEvents();
        }

        private void OnDestroy()
        {
            TryUnsubscribeMovementSystemsFromPlayerEvents();
        }

        private void Update()
        {

            activeMovementSystem.OnUpdate(
                characterController,
                Time.deltaTime);
        }

        private void SetAllEnabled(bool state)
        {
            walkMovementSystem.Enabled = state;
            swimMovementSystem.Enabled = state;
        }

        private void SetDefaultMovementSystem()
        {
            switch (defaultMovementSystem)
            {
                case MovementSystemTypes.Walk:
                    Active = walkMovementSystem;
                    break;
                case MovementSystemTypes.Swim:
                    Active = swimMovementSystem;
                    break;
            }
        }

        private void SubscribeMovementSystemsToPlayerEvents()
        {
            IPlayerEvents events = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            walkMovementSystem.SubscribeToEvents(events);
            swimMovementSystem.SubscribeToEvents(events);
        }

        private void TryUnsubscribeMovementSystemsFromPlayerEvents()
        {
            if (AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver iao))
            {
                IPlayerEvents events = iao.Player;

                walkMovementSystem.UnsubscribeFromEvents(events);
                swimMovementSystem.UnsubscribeFromEvents(events);
            }
        }

        // Structs

        // Classes
        public enum MovementSystemTypes
        {
            Walk,
            Swim
        }
    }
}
