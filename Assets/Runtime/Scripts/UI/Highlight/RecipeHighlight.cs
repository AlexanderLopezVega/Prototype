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
        [SerializeField] private GameObject requiredToolUIPrefab = default;
        [SerializeField] private GameObject ingredientUIPrefab = default;

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
            GameObject ingredientUIClone = Instantiate(ingredientUIPrefab, ingredientsRoot, false);

            MaterialListEntry ingredientUI = ingredientUIClone.GetComponent<MaterialListEntry>();

            ingredientUI.Name = ingredientStack.Item.Name;
            ingredientUI.CategoryIcon = ingredientStack.Item.Category.Icon;
            ingredientUI.HeldAmount = 0; // TODO: Fetch stack amount in inventory of this ingredient item
            ingredientUI.RequiredAmount = ingredientStack.Amount;
        }

        private void CreateRequiredToolUI(Item requiredTool)
        {
            GameObject requiredToolUIClone = Instantiate(requiredToolUIPrefab, requiredToolsRoot, false);

            RequiredToolListEntry requiredToolUI = requiredToolUIClone.GetComponent<RequiredToolListEntry>();

            requiredToolUI.Name = requiredTool.Name;
            requiredToolUI.CategoryIcon = requiredTool.Category.Icon;
        }
    }
}
