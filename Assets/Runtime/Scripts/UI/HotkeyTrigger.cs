using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype.ui
{
    public class HotkeyTrigger : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputActionReference inputHotkey = default;
        [Header("Events")]
        [SerializeField] private UnityEvent onHotkeyStartedEvent = default;
        [SerializeField] private UnityEvent onHotkeyPerformedEvent = default;
        [SerializeField] private UnityEvent onHotkeyCanceledEvent = default;

        private InputAction inputAction = default;

        private void Start()
        {
            inputAction = inputHotkey.ToInputAction();

            inputAction.started += OnHotkeyStarted;
            inputAction.performed += OnHotkeyPerformed;
            inputAction.canceled += OnHotkeyCanceled;

            inputAction.Enable();
        }
        private void OnDestroy()
        {
            inputAction.started -= OnHotkeyStarted;
            inputAction.performed -= OnHotkeyPerformed;
            inputAction.canceled -= OnHotkeyCanceled;

            inputAction.Disable();
        }

        private void OnHotkeyStarted(CallbackContext ctx) => onHotkeyStartedEvent.Invoke();
        private void OnHotkeyPerformed(CallbackContext ctx) => onHotkeyPerformedEvent.Invoke();
        private void OnHotkeyCanceled(CallbackContext ctx) => onHotkeyCanceledEvent.Invoke();
    }
}
