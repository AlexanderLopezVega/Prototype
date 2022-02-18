using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class InputActionsObserver : MonoBehaviour
    {
        // Constant Fields

        // Fields
        private Controls controls = default;

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties
        public IPlayerEvents Player { get; private set; }

        // Indexers

        // Methods
        private void Awake()
        {
            controls = new Controls();

            PlayerActionsObserver pao = new PlayerActionsObserver();

            Player = pao;
            controls.Player.SetCallbacks(pao);
        }

        private void OnEnable() => controls.Enable();
        private void OnDisable() => controls.Disable();

        // Structs

        // Classes
    }
}
