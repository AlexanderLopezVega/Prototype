using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    using TMPUGUI = TextMeshProUGUI;

    public class RecipeListEntry : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private Image iconImage = default;

        public string Name { get => nameText.text; set => nameText.text = value; }
        public Sprite OutputIcon { set => iconImage.sprite = value; }
    }
}
