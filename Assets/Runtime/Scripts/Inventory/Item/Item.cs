using System;

namespace com.alexlopezvega.prototype.inventory
{
    public abstract class Item
    {
        public ulong AssetItemID { get; private set; }

        protected Item(ulong assetItemID)
        {
            AssetItemID = assetItemID;
        }
    }
}
