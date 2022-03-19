namespace com.alexlopezvega.prototype.inventory
{
    [System.Serializable]
    public class ItemStack
    {
        public Item item;
        public uint amount;

        public ItemStack(Item item, uint amount)
        {
            this.item = item;
            this.amount = amount;
        }
    }
}
