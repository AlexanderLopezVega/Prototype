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
        [SerializeField] private GameObject listEntryPrefab = default;

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
            GameObject listEntryClone = Instantiate(listEntryPrefab, itemsRoot, false);
            ListEntry listEntry = listEntryClone.GetComponent<ListEntry>();

            listEntry.Name = itemStack.Item.Name;
            //itemStackUI.CategoryIcon = itemStack.Item.Category.Icon;
            listEntry.Amount = itemStack.Amount;

            listEntryClone.GetComponent<Button>().onClick.AddListener(() => highlightView.RenderItem(itemStack.Item));
        }

        private void CreateRecipeUI(Recipe recipe)
        {
            GameObject listEntryClone = Instantiate(listEntryPrefab, recipesRoot, false);

            ListEntry recipeUI = listEntryClone.GetComponent<ListEntry>();

            recipeUI.Name = recipe.Output.Item.Name;
            recipeUI.Amount = 1;
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
