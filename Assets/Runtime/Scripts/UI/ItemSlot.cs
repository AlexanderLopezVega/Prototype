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
        [field: SerializeField] public ItemStack ItemStack { get; private set; }

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

            ItemSlot itemSlot = eventData.pointerDrag.GetComponent<ItemSlot>();

            if (itemSlot.ItemStack == null)
                return;

            itemSlot.SwapItem(this);
        }

        public void SetItemStack(ItemStack itemStack)
        {
            ItemStack = itemStack;
            UpdateImageSprite();
        }

        private void SwapItem(ItemSlot newItemSlot)
        {
            ItemStack temp = ItemStack;

            this.ItemStack = newItemSlot.ItemStack;
            newItemSlot.ItemStack = temp;

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
            if (ItemStack == null || ItemStack.Item == null)
            {
                SetImageAlpha(0f);
                image.sprite = null;
            }
            else
            {
                SetImageAlpha(1f);
                image.sprite = ItemStack.Item.Sprite;
            }
        }
    }
}
