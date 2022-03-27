using UnityEngine;
using UnityEngine.Events;

namespace com.alexlopezvega.prototype
{
    public class ActiveHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private GameObject root = default;
        [Header("Events")]
        [SerializeField] private UnityEvent<bool> onDeactivateEvent = default;

        public void ToggleInHierarchy() => SetActive(!root.activeInHierarchy);
        public void ToggleSelf() => SetActive(!root.activeSelf);

        public void SetActive(bool state)
        {
            root.SetActive(state);

            if (!state)
                onDeactivateEvent.Invoke(state);
        }
    }
}
