using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    using TMPUGUI = TextMeshProUGUI;

    public class MaterialListEntry : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private Image iconImage = default;
        [SerializeField] private TMPUGUI heldAmountText = default;
        [SerializeField] private TMPUGUI requiredAmountText = default;

        public string Name { get => nameText.text; set => nameText.text = $"{value}"; }
        public Sprite CategoryIcon { set => iconImage.sprite = value; }
        public float HeldAmount { set => heldAmountText.text = $"{value}"; }
        public float RequiredAmount { set => requiredAmountText.text = $"{value}"; }
    }
}
