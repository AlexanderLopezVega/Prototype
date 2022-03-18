using com.alexlopezvega.prototype.inventory;
using TMPro;
using UnityEngine;

namespace com.alexlopezvega.prototype.ui
{
    public class RecipeButton : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI recipeTMP = default;
        [SerializeField] private Recipe recipe = default;

        private void OnValidate()
        {
            if (recipeTMP != null && recipe != null)
                UpdateText();
        }

        private void UpdateText()
        {
            recipeTMP.text = recipe.name;
        }
    }
}
