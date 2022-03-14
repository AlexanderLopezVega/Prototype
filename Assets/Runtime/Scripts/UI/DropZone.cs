using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    public class DropZone : MonoBehaviour, IDropHandler
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform dropRoot = default;
        [SerializeField] private Image dropZoneSprite = default;

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            DragDropBehaviour dragDrop = eventData.pointerDrag.GetComponent<DragDropBehaviour>();

            dropZoneSprite.sprite = dragDrop.Sprite;

            dragDrop.OnDropZoneCaptured(this);
        }
    }
}
