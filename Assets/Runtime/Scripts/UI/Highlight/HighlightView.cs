using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    using TMPUGUI = TextMeshProUGUI;

    public class HighlightView : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private TMPUGUI descriptionText = default;
        [SerializeField] private Image icon = default;
        [SerializeField] private RectTransform detailsRoot = default;

        private HighlightRenderer highlightRenderer = default;

        public string Name
        {
            set => nameText.text = value;
        }
        public string Description
        {
            set => descriptionText.text = value;
        }
        public Sprite Sprite
        {
            set => icon.sprite = value;
        }
        public RectTransform DetailsRoot => detailsRoot;

        public HighlightRenderer HighlightRenderer
        {
            get => highlightRenderer;
            set
            {
                highlightRenderer.OnRenderingStop(this);
                highlightRenderer = value;
                highlightRenderer.OnRenderingStart(this);
            }
        }
    }
}
