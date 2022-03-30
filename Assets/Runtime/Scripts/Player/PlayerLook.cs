using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerLook : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Transform cameraRoot = default;

        private bool shouldUpdateForward = default;

        private void Update()
        {
            if (shouldUpdateForward)
                UpdateForward();
        }

        private void UpdateForward()
        {
            Vector3 projCamToPlayer = Vector3.ProjectOnPlane(playerRoot.position - cameraRoot.position, Vector3.up).normalized;

            playerRoot.rotation = Quaternion.LookRotation(projCamToPlayer, Vector3.up);
        }

        public void OnMove(InputValue value)
        {
            shouldUpdateForward = value.Get<Vector2>() != default;
        }
    }
}
