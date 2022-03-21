using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [System.Serializable]
    public class ItemStack
    {
        [field: SerializeField] public Item Item { get; set; }
        [field: SerializeField] public uint Amount { get; set; }

        public ItemStack(Item item, uint amount)
        {
            Item = item;
            Amount = amount;
        }

        public ItemStack() : this(default, default)
        {

        }
    }
}
