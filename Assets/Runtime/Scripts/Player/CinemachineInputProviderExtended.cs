using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.alexlopezvega.prototype
{
    public class CinemachineInputProviderExtended : CinemachineInputProvider
    {
        [Space]
        [SerializeField] private InputActionReference storedLookAction = default;

        private void Start()
        {
            SetInputEnabled(true);
        }

        public void SetInputEnabled(bool state)
        {
            XYAxis = (state) ? storedLookAction : null;
        }
    }
}
