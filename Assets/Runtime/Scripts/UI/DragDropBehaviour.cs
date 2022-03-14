using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    public class DragDropBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private const float DragAlpha = 0.6f;
        
        [Header("Dependencies")]
        [SerializeField] private DragHandler dragHandler = default;
        [SerializeField] private RectTransform root = default;
        [SerializeField] private Image image = default;

        public Sprite Sprite => image.sprite;

        public void OnBeginDrag(PointerEventData eventData)
        {
            dragHandler.OnDragEnter(eventData, root, image);
            SetImageAlpha(DragAlpha);
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragHandler.OnDragStay(eventData, root);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragHandler.OnDragExit(eventData, root);
            SetImageAlpha(1f);
        }

        public void OnDropZoneCaptured(DropZone dropZone)
        {

        }

        private void SetImageAlpha(float alpha)
        {
            Color imageColor = image.color;
            imageColor.a = alpha;
            image.color = imageColor;
        }
    }
}
