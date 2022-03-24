using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class ActiveToggle : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private GameObject root = default;

        public void ToggleInHierarchy() => root.SetActive(!root.activeInHierarchy);
        public void ToggleSelf() => root.SetActive(!root.activeSelf);
    }
}
