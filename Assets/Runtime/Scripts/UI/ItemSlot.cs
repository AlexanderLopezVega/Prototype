using com.alexlopezvega.prototype.inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [Header("Dependencies")]
        [SerializeField] private DragImage dragHandler = default;
        [SerializeField] private Image image = default;
        [field: Header("Data")]
        [field: SerializeField] public Item Item { get; private set; }

        private void Start() => UpdateImageSprite();

        private void OnValidate()
        {
            if (image == null)
                return;

            UpdateImageSprite();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            dragHandler.Sprite = image.sprite;
            dragHandler.Position = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragHandler.Position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragHandler.Sprite = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null || eventData.pointerDrag == gameObject)
                return;

            eventData.pointerDrag.GetComponent<ItemSlot>().SwapItem(this);
        }

        private void SwapItem(ItemSlot newItemSlot)
        {
            Item temp = Item;

            this.Item = newItemSlot.Item;
            newItemSlot.Item = temp;

            this.UpdateImageSprite();
            newItemSlot.UpdateImageSprite();
        }

        private void SetImageAlpha(float alpha)
        {
            Color imageColor = image.color;
            imageColor.a = alpha;
            image.color = imageColor;
        }

        private void UpdateImageSprite()
        {
            if (Item == null)
            {
                SetImageAlpha(0f);
                image.sprite = null;
            }
            else
            {
                SetImageAlpha(1f);
                image.sprite = Item.Sprite;
            }
        }
    }
}
