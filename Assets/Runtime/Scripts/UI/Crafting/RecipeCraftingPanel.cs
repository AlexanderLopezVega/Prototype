using com.alexlopezvega.prototype.inventory;
using Multiscene.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    using TMPUGUI = TextMeshProUGUI;

    public class RecipeCraftingPanel : MonoBehaviour, IBootListener, IInventoryObserver
    {
        private const string InputTextName = "Input Text";

        [Header("Dependencies")]
        [SerializeField] private RectTransform panelRoot = default;
        [SerializeField] private RectTransform detailsRoot = default;
        [Space]
        [SerializeField] private GameObject detailsInputTextPrefab = default;
        [Space]
        [SerializeField] private Image outputItemIconImage = default;
        [SerializeField] private TMPUGUI outputItemNameText = default;
        [SerializeField] private Button craftButton = default;

        private Recipe recipe = default;
        private Inventory inventory = default;

        public Recipe Recipe
        {
            get => recipe;
            set
            {
                recipe = value;

                OnRecipeChanged();
            }
        }

        private void Start() => UpdateRecipeUI();

        public void OnSceneCollectionLoaded()
        {
            AssetFinder.TryFindComponent(TagCts.Player, out inventory);

            inventory.AddObserver(this);
        }

        public void OnItemAdded(Item item, uint previousAmount, uint currentAmount) => OnInventoryChanged();
        public void OnItemRemoved(Item item, uint previousAmount, uint currentAmount) => OnInventoryChanged();
        public void OnRegister(Dictionary<Item, ItemStack> itemMap) { }

        public void TryCraftRecipe()
        {
            if (!HasEnoughInputs())
                return;

            ConsumeInputs();
            ProduceOutput();
        }

        private void AddRecipeInputDetail(ItemStack itemStack, bool hasEnoughInput)
        {
            GameObject inputTextClone = Instantiate(detailsInputTextPrefab, detailsRoot);
            inputTextClone.name = InputTextName;

            TMPUGUI tmpText = inputTextClone.GetComponent<TMPUGUI>();

            tmpText.text = $"{itemStack.amount} x {itemStack.item.Name}";
            tmpText.color = hasEnoughInput ? Color.white : Color.red;
        }

        private void ConsumeInputs()
        {
            foreach (var itemStack in recipe.Inputs)
                inventory.RemoveItem(itemStack);
        }

        private bool HasEnoughInputs()
        {
            foreach (var itemStack in recipe.Inputs)
                if (!inventory.HasEnough(itemStack))
                    return false;

            return true;
        }

        private void OnInventoryChanged() => UpdateRecipeUI();

        private void OnRecipeChanged() => UpdateRecipeUI();

        private void ProduceOutput()
        {
            inventory.AddItem(recipe.Output);
        }

        private void UpdateRecipeUI()
        {
            if (recipe == null)
            {
                panelRoot.gameObject.SetActive(false);

                return;
            }

            panelRoot.gameObject.SetActive(true);

            bool missingRecipeInput = false;

            // Details
            detailsRoot.Clear();

            foreach (var itemStack in recipe.Inputs)
            {
                bool hasEnoughInput = inventory.HasEnough(itemStack);

                missingRecipeInput |= !hasEnoughInput;

                AddRecipeInputDetail(itemStack, hasEnoughInput);
            }

            // Item
            Item item = recipe.Output.item;

            outputItemIconImage.sprite = item.Sprite;
            outputItemNameText.text = item.name;

            // Crafting
            craftButton.interactable = !missingRecipeInput;
        }
    }
}
