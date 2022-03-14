using System;

namespace com.alexlopezvega.prototype.inventory
{
    [AttributeUsage(validOn: AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RecipeInputAttribute : Attribute
    {
        public ulong ItemID { get; private set; }
        public uint Amount { get; private set; }

        public RecipeInputAttribute(ulong itemID, uint amount)
        {
            ItemID = itemID;
            Amount = amount;
        }
    }
}
