using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    public class DragHandler : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform dragRoot = default;
        [SerializeField] private Image dragImage = default;
        [SerializeField] private Canvas canvas = default;
        [SerializeField] private CanvasGroup canvasGroup = default;

        private void Start()
        {
            SetDragImage(null);
            canvasGroup.blocksRaycasts = false;
        }

        private void Move(Vector2 delta)
        {
            dragRoot.anchoredPosition += delta;
        }

        public void OnDragEnter(PointerEventData eventData, RectTransform root, Image image)
        {
            SetDragImage(image);
            SetPosition(eventData.position);
        }

        public void OnDragStay(PointerEventData eventData, RectTransform root)
        {
            Move(eventData.delta / canvas.scaleFactor);
        }

        public void OnDragExit(PointerEventData eventData, RectTransform root)
        {
            SetDragImage(null);
        }

        private void SetDragImage(Image image)
        {
            if (image != null)
            {
                dragImage.sprite = image.sprite;
                canvasGroup.alpha = 1f;
            }
            else
            {
                dragImage.sprite = null;
                canvasGroup.alpha = 0f;
            }
        }

        private void SetPosition(Vector3 position)
        {
            dragRoot.position = position;
        }
    }
}
