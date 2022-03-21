using Multiscene.Runtime;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerUI : MonoBehaviour, IBootListener
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform inventoryRoot = default;
        [SerializeField] private RectTransform craftingRoot = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            IPlayerEvents player = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            player.OnToggleInventoryActionEvent += OnToggleInventoryAction;
            player.OnToggleCraftingActionEvent += OnToggleCraftingAction;
        }

        private void OnToggleInventoryAction(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                ToggleInventory();

                if (craftingRoot.gameObject.activeSelf)
                    ToggleCrafting();
            }
        }
        private void OnToggleCraftingAction(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                ToggleCrafting();

                if (!inventoryRoot.gameObject.activeSelf)
                    ToggleInventory();
            }
        }

        private void ToggleInventory()
        {
            inventoryRoot.gameObject.SetActive(!inventoryRoot.gameObject.activeSelf);
        }
        private void ToggleCrafting()
        {
            craftingRoot.gameObject.SetActive(!craftingRoot.gameObject.activeSelf);
        }
    }
}
