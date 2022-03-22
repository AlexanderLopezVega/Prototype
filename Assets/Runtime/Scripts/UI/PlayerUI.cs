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

        private CinemachineInputProviderExtended inputProvider = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            inputProvider = AssetFinder.FindComponent<CinemachineInputProviderExtended>(TagCts.PlayerCamera);
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

                CheckEnableCameraInput();
            }
        }

        private void OnToggleCraftingAction(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                ToggleCrafting();

                if (!inventoryRoot.gameObject.activeSelf)
                    ToggleInventory();

                CheckEnableCameraInput();
            }
        }

        private void CheckEnableCameraInput()
        {
            bool craftingEnabled = craftingRoot.gameObject.activeSelf;
            bool inventoryEnabled = inventoryRoot.gameObject.activeSelf;

            if (!(craftingEnabled || inventoryEnabled))
                inputProvider.SetInputEnabled(true);
            else
                inputProvider.SetInputEnabled(false);
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
