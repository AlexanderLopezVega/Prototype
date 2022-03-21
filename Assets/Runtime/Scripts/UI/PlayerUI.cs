using Multiscene.Runtime;
using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerUI : MonoBehaviour, IBootListener
    {
        [Header("Dependencies")]
        [SerializeField] private RectTransform inventoryRoot = default;
        [SerializeField] private RectTransform craftingRoot = default;

        public event Action OnAllPanelsDisabledEvent = default;
        public event Action OnAnyPanelEnabledEvent = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            IPlayerEvents player = AssetFinder.FindComponent<InputActionsObserver>(TagCts.InputActionsObserver).Player;

            player.OnToggleInventoryActionEvent += OnToggleInventoryAction;
            player.OnToggleCraftingActionEvent += OnToggleCraftingAction;
        }
        private void OnDestroy()
        {
            if (!AssetFinder.TryFindComponent(TagCts.InputActionsObserver, out InputActionsObserver iao))
                return;

            IPlayerEvents player = iao.Player;

            player.OnToggleInventoryActionEvent -= OnToggleInventoryAction;
            player.OnToggleCraftingActionEvent -= OnToggleCraftingAction;
        }

        private void OnToggleInventoryAction(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                ToggleInventory();

                if (craftingRoot.gameObject.activeSelf)
                    ToggleCrafting();

                CheckEvents();
            }
        }

        private void OnToggleCraftingAction(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                ToggleCrafting();

                if (!inventoryRoot.gameObject.activeSelf)
                    ToggleInventory();

                CheckEvents();
            }
        }

        private void CheckEvents()
        {
            bool craftingEnabled = craftingRoot.gameObject.activeSelf;
            bool inventoryEnabled = inventoryRoot.gameObject.activeSelf;

            if (!(craftingEnabled || inventoryEnabled))
                OnAllPanelsDisabledEvent?.Invoke();
            else
                OnAnyPanelEnabledEvent?.Invoke();
        }

        private void ToggleCrafting()
        {
            craftingRoot.gameObject.SetActive(!craftingRoot.gameObject.activeSelf);
        }
        private void ToggleInventory()
        {
            inventoryRoot.gameObject.SetActive(!inventoryRoot.gameObject.activeSelf);
        }
    }
}
