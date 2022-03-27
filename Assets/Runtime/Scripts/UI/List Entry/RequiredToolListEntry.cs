using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    using TMPUGUI = TextMeshProUGUI;

    public class RequiredToolListEntry : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private Image iconImage = default;

        public string Name { set => nameText.text = $"{value}"; }
        public Sprite CategoryIcon { set => iconImage.sprite = value; }
    }
}
