using System.Collections.Generic;

namespace com.alexlopezvega.prototype.inventory
{
    public interface IInventoryObserver
    {
        void OnRegister(in Dictionary<Item, ItemStack> itemStackMap, in ISet<Recipe> recipeSet);
        
        void OnItemAdded(in Dictionary<Item, ItemStack> itemStackMap, in ItemStack previousStack, in ItemStack currentStack);
        void OnItemRemoved(in Dictionary<Item, ItemStack> itemStackMap, in ItemStack previousStack, in ItemStack currentStack);

        void OnRecipeAdded(in ISet<Recipe> recipeSet, in Recipe recipe);
        void OnRecipeRemoved(in ISet<Recipe> recipeSet, in Recipe recipe);
    }
}
