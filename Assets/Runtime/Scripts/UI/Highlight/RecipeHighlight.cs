using com.alexlopezvega.prototype.inventory;
using UnityEngine;

namespace com.alexlopezvega.prototype.ui
{
    public class RecipeHighlight : Highlight<Recipe>
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform requiredToolsRoot = default;
        [SerializeField] private RectTransform ingredientsRoot = default;
        [Space]
        [SerializeField] private GameObject listEntryPrefab = default;

        public override void SetHighlight(Recipe recipe)
        {
            requiredToolsRoot.Clear();
            ingredientsRoot.Clear();

            foreach (var requiredTool in recipe.RequiredTools)
                CreateRequiredToolUI(requiredTool);

            foreach (var ingredient in recipe.Materials)
                CreateIngredientUI(ingredient);
        }

        private void CreateIngredientUI(ItemStack ingredientStack)
        {
            GameObject listEntryClone = Instantiate(listEntryPrefab, ingredientsRoot, false);

            ListEntry ingredientUI = listEntryClone.GetComponent<ListEntry>();

            ingredientUI.Name = ingredientStack.Item.Name;
            //ingredientUI.CategoryIcon = ingredientStack.Item.Category.Icon;
            ingredientUI.Amount = 0; // TODO: Fetch stack amount in inventory of this ingredient item
            ingredientUI.NecessaryAmount = ingredientStack.Amount;
        }

        private void CreateRequiredToolUI(Item requiredTool)
        {
            GameObject listEntryClone = Instantiate(listEntryPrefab, requiredToolsRoot, false);

            ListEntry listEntry = listEntryClone.GetComponent<ListEntry>();

            listEntry.Name = requiredTool.Name;
            listEntry.Amount = 0;
            listEntry.NecessaryAmount = 1;
            //requiredToolUI.CategoryIcon = requiredTool.Category.Icon;
        }
    }
}
