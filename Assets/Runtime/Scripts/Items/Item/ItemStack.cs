using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [System.Serializable]
    public class ItemStack
    {
        [SerializeField] private Item item = default;
        [SerializeField] private uint amount = default;

        public Item Item => item;
        public uint Amount
        {
            get => amount;
            set => amount = value;
        }

        public ItemStack(Item item, uint amount)
        {
            this.item = item;
            this.amount = amount;
        }
        public ItemStack() : this(default, default) { }
        public ItemStack(ItemStack other): this(other.Item, other.Amount) { }

        public float CalculateWeight() => amount * item.Weight;
    }
}
