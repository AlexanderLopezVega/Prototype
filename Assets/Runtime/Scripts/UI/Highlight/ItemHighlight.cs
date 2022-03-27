using com.alexlopezvega.prototype.inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    using TMPUGUI = TextMeshProUGUI;

    public class ItemHighlight : Highlight<Item>
    {
        [Header("Dependencies)")]
        [SerializeField] private TMPUGUI nameTMP = default;
        [SerializeField] private TMPUGUI descriptionTMP = default;
        [SerializeField] private Image iconImage= default;

        public override void SetHighlight(Item item)
        {
            nameTMP.text = item.Name;
            descriptionTMP.text = item.Description;
            iconImage.sprite = item.Icon;
        }
    }
}
