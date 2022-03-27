using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    using TMPUGUI = TextMeshProUGUI;

    public class ItemStackListEntry : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private TMPUGUI amountText = default;
        [SerializeField] private Image iconImage = default;

        public string Name { get => nameText.text; set => nameText.text = value; }
        public float HeldAmount { set => amountText.text = $"{value}"; }
        public Sprite CategoryIcon { set => iconImage.sprite = value; }
    }
}
