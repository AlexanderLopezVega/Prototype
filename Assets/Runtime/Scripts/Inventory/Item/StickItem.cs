namespace com.alexlopezvega.prototype.inventory
{
    [Ingredient]
    [StackSize(99)]
    public class StickItem : Item
    {
        public StickItem() : base(AssetItemIDCts.Stick) { }
    }
}
