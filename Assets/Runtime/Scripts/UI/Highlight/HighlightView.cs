using com.alexlopezvega.prototype.inventory;
using UnityEngine;

namespace com.alexlopezvega.prototype.ui
{
    public class HighlightView : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private GameObject highlightWindowRoot = default;
        [Space]
        [SerializeField] private ItemHighlight itemRenderer = default;
        [SerializeField] private RecipeHighlight recipeRenderer = default;

        public void RenderItem(Item item)
        {
            highlightWindowRoot.SetActive(true);

            itemRenderer.SetActive(true);
            recipeRenderer.SetActive(false);

            itemRenderer.SetHighlight(item);
        }
        public void RenderRecipe(Recipe recipe)
        {
            highlightWindowRoot.SetActive(true);

            itemRenderer.SetActive(true);
            itemRenderer.SetActive(true);

            itemRenderer.SetHighlight(recipe.Output.Item);
            recipeRenderer.SetHighlight(recipe);
        }
    }
}
