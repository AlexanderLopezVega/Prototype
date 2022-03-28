using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype
{
    using TMPUGUI = TextMeshProUGUI;

    public class ListEntry : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TMPUGUI nameText = default;
        [SerializeField] private RectTransform categoryContainer = default;
        [SerializeField] private TMPUGUI amountText = default;

        private float amount = default;
        private float necessaryAmount = default;

        public string Name { set => nameText.text = value; }
        public List<Category> Categories { set => SetupCategories(value); }
        public float Amount
        {
            set
            {
                Assert.IsTrue(value > 0);

                amount = value;
                amountText.text = (value > 1) ? $"{value}" : "";
            }
        }
        public float NecessaryAmount
        {
            set
            {
                necessaryAmount = value;

                if (value > 0)
                    amountText.text = $"({amount}/{value})";
            }
        }

        private void SetupCategories(List<Category> categories)
        {
            categoryContainer.Clear();

            foreach (var category in categories)
            {
                GameObject categoryIcon = new GameObject("Category Icon");

                categoryIcon.AddComponent<CanvasRenderer>();
                categoryIcon.AddComponent<Image>().sprite = category.Icon;
            }
        }
    }
}
