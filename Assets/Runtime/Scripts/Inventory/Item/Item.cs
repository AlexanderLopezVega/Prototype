namespace com.alexlopezvega.prototype.inventory
{
    public abstract class Item
    {
        public ulong ItemID { get; private set; }

        protected Item(ulong assetItemID)
        {
            ItemID = assetItemID;
        }
    }
}
