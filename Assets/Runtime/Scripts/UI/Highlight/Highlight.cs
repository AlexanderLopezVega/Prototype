using UnityEngine;

namespace com.alexlopezvega.prototype.ui
{
    public abstract class Highlight<T> : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform root = default;

        public void SetActive(bool state) => root.gameObject.SetActive(state);

        public abstract void SetHighlight(T t);
    }
}
