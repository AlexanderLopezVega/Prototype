using com.alexlopezvega.prototype.inventory;

namespace com.alexlopezvega.prototype.ui
{
    public class ItemRenderer : HighlightRenderer
    {
        private readonly Item item = default;

        public ItemRenderer(Item item)
        {
            this.item = item;
        }

        public override void OnRenderingStart(HighlightView view)
        {
            view.DetailsRoot.Clear();

            view.Sprite = item.Sprite;
            view.Name = item.Name;
            view.Description = item.Description;
        }

        public override void OnRenderingStop(HighlightView view)
        {

        }
    }
}
