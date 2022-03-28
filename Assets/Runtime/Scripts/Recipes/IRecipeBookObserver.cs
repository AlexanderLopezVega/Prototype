using System.Collections.Generic;

namespace com.alexlopezvega.prototype.recipes
{
    public interface IRecipeBookObserver
    {
        void OnRegister(in ISet<Recipe> recipeSet);
        void OnRecipeAdded(in ISet<Recipe> recipeSet, in Recipe addedRecipe);
        void OnRecipeRemoved(in ISet<Recipe> recipeSet, in Recipe removedRecipe);
    }
}
