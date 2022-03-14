using System;

namespace com.alexlopezvega.prototype.inventory
{
    public class InventoryException : Exception
    {
        public InventoryException(string message) : base(message) { }
    }
}
