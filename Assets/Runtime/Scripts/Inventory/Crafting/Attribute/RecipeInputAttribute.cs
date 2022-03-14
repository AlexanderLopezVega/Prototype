using System;

namespace com.alexlopezvega.prototype.inventory
{
    public class RecipeInputAttribute : Attribute
    {
        private Type ingredient = default;
        private int amount = default;

        public RecipeInputAttribute(Type ingredient, int amount)
        {
            this.ingredient = ingredient;
            this.amount = amount;
        }
    }
}
