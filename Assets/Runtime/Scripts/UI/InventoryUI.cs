using com.alexlopezvega.prototype.inventory;
using Multiscene.Runtime;
using ScriptableObjectData.Runtime.SOData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.alexlopezvega.prototype.ui
{
    public class InventoryUI : MonoBehaviour, IBootListener, IInventoryObserver
    {
        [Header("Dependencies")]
        [SerializeField] private StringReference playerTag = default;
        [SerializeField] private HighlightView highlightView = default;
        [Space]
        [SerializeField] private RectTransform itemsRoot = default;
        [SerializeField] private RectTransform recipesRoot = default;
        [Space]
        [SerializeField] private GameObject itemStackUIPrefab = default;
        [SerializeField] private GameObject recipeUIPrefab = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            AssetFinder.FindComponent<Inventory>(playerTag).AddObserver(this);
        }

        void IInventoryObserver.OnRegister(in Dictionary<Item, ItemStack> itemStackMap, in ISet<Recipe> recipeSet)
        {
            OnItemsUpdated(itemStackMap);
            OnRecipeUpdated(recipeSet);
        }

        void IInventoryObserver.OnItemAdded(in Dictionary<Item, ItemStack> itemStackMap, in ItemStack previousStack, in ItemStack currentStack)
        {
            OnItemsUpdated(itemStackMap);
        }

        void IInventoryObserver.OnItemRemoved(in Dictionary<Item, ItemStack> itemStackMap, in ItemStack previousStack, in ItemStack currentStack)
        {
            OnItemsUpdated(itemStackMap);
        }

        void IInventoryObserver.OnRecipeAdded(in ISet<Recipe> recipeSet, in Recipe recipe)
        {
            OnRecipeUpdated(recipeSet);
        }

        void IInventoryObserver.OnRecipeRemoved(in ISet<Recipe> recipeSet, in Recipe recipe)
        {
            OnRecipeUpdated(recipeSet);
        }

        public void FilterBy(string filter)
        {
            foreach(Transform itemChild in itemsRoot)
                itemChild.gameObject.SetActive(itemChild.GetComponent<ItemStackListEntry>().Name.ContainsIgnoreCase(filter));

            foreach (Transform recipeChild in recipesRoot)
                recipeChild.gameObject.SetActive(recipeChild.GetComponent<RecipeListEntry>().Name.ContainsIgnoreCase(filter));
        }

        private void CreateItemStackUI(ItemStack itemStack)
        {
            GameObject itemStackUIClone = Instantiate(itemStackUIPrefab, itemsRoot, false);

            ItemStackListEntry itemStackUI = itemStackUIClone.GetComponent<ItemStackListEntry>();

            itemStackUI.Name = itemStack.Item.Name;
            itemStackUI.CategoryIcon = itemStack.Item.Category.Icon;
            itemStackUI.HeldAmount = itemStack.Amount;

            itemStackUIClone.GetComponent<Button>().onClick.AddListener(() => highlightView.RenderItem(itemStack.Item));
        }

        private void CreateRecipeUI(Recipe recipe)
        {
            GameObject recipeUIClone = Instantiate(recipeUIPrefab, itemsRoot, false);

            RecipeListEntry recipeUI = recipeUIClone.GetComponent<RecipeListEntry>();

            recipeUI.Name = recipe.Output.Item.Name;
            recipeUI.OutputIcon = recipe.Output.Item.Icon;
        }

        private void OnItemsUpdated(Dictionary<Item, ItemStack> itemStackMap)
        {
            itemsRoot.Clear();

            foreach (var itemStack in itemStackMap.Values)
                CreateItemStackUI(itemStack);
        }

        private void OnRecipeUpdated(in ISet<Recipe> recipeSet)
        {
            recipesRoot.Clear();

            foreach (var recipe in recipeSet)
                CreateRecipeUI(recipe);
        }
    }
}
