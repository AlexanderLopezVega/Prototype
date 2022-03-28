using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace com.alexlopezvega.prototype.recipes
{
    public class RecipeBook : MonoBehaviour
    {
        private ISet<Recipe> recipeSet = default;

        private ISet<IRecipeBookObserver> recipeObserverSet = default;

        private void Start()
        {
            recipeSet = new HashSet<Recipe>();
            recipeObserverSet = new HashSet<IRecipeBookObserver>();
        }

        public bool AddRecipe(Recipe recipe)
        {
            Assert.IsNotNull(recipe);

            bool recipeWasAdded = recipeSet.Add(recipe);

            if (recipeWasAdded)
                NotifyObservers(observer => observer.OnRecipeAdded(recipeSet, recipe));

            return recipeWasAdded;
        }

        public bool RemoveRecipe(Recipe recipe)
        {
            Assert.IsNotNull(recipe);

            bool recipeWasRemoved =  recipeSet.Remove(recipe);

            if (recipeWasRemoved)
                NotifyObservers(observer => observer.OnRecipeRemoved(recipeSet, recipe));

            return recipeWasRemoved;
        }

        public bool HasRecipe(Recipe recipe)
        {
            Assert.IsNotNull(recipe);

            return recipeSet.Contains(recipe);
        }

        #region Observer
        public void AddObserver(IRecipeBookObserver observer)
        {
            Assert.IsNotNull(observer);

            if (recipeObserverSet.Add(observer))
                observer.OnRegister(recipeSet);
        }

        public void RemoveObserver(IRecipeBookObserver observer)
        {
            Assert.IsNotNull(observer);

            recipeObserverSet.Remove(observer);
        }

        private void NotifyObservers(Action<IRecipeBookObserver> observerAction)
        {
            foreach (var observer in recipeObserverSet)
                observerAction.Invoke(observer);
        }
        #endregion
    }
}
