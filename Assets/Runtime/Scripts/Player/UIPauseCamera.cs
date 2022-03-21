using Cinemachine;
using Multiscene.Runtime;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class UIPauseCamera : MonoBehaviour, IBootListener
    {
        [Header("Dependencies")]
        [SerializeField] private CinemachineFreeLook freeLook = default;

        void IBootListener.OnSceneCollectionLoaded()
        {
            PlayerUI playerUI = AssetFinder.FindComponent<PlayerUI>(TagCts.PlayerUI);

            playerUI.OnAllPanelsDisabledEvent += OnAllPanelsDisabled;
            playerUI.OnAnyPanelEnabledEvent += OnAnyPanelEnabled;
        }
        private void OnDestroy()
        {
            if (!AssetFinder.TryFindComponent(TagCts.PlayerUI, out PlayerUI playerUI))
                return;

            playerUI.OnAllPanelsDisabledEvent -= OnAllPanelsDisabled;
            playerUI.OnAnyPanelEnabledEvent -= OnAnyPanelEnabled;
        }

        private void OnAllPanelsDisabled() => SetCanMoveCamera(true);
        private void OnAnyPanelEnabled() => SetCanMoveCamera(false);

        private void SetCanMoveCamera(bool state)
        {

        }
    }
}
