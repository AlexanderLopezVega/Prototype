using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    public class DragImage : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform dragRoot = default;
        [SerializeField] private Image dragImage = default;
        [SerializeField] private CanvasGroup canvasGroup = default;

        public Sprite Sprite
        {
            get => dragImage.sprite;
            set
            {
                dragImage.sprite = value;

                SetVisible(value != null);
            }
        }

        public Vector2 Position
        {
            get => dragRoot.position;
            set => dragRoot.position = value;
        }

        private void SetVisible(bool isVisible)
        {

            canvasGroup.alpha = (isVisible) ? 0.6f : 0f;
        }
    }
}
