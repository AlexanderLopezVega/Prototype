namespace com.alexlopezvega.prototype.inventory
{
    public class StackSizeAttribute : ItemAttribute
    {
        public int MaximumAmount {get; private set;}

        public StackSizeAttribute(int maximumAmount)
        {
            MaximumAmount = maximumAmount;
        }
    }
}
