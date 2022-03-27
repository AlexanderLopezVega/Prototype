using ScriptableObjectData.Runtime.SOData;
using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace com.alexlopezvega.prototype
{
    public class PlayerLook : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform playerRoot = default;
        [SerializeField] private Transform cameraRoot = default;
        [Space]
        [SerializeField] private StringReference inputActionsObserverTag = default;

        private bool shouldUpdateForward = default;

        private void Start()
        {
            AssetFinder.FindComponent<InputActionsObserver>(inputActionsObserverTag).Player.OnMoveActionEvent += OnMoveAction;
        }
        private void OnDestroy()
        {
            if (!AssetFinder.TryFindComponent(inputActionsObserverTag, out InputActionsObserver iao))
                return;

            iao.Player.OnMoveActionEvent -= OnMoveAction; 
        }

        private void Update()
        {
            if (shouldUpdateForward)
                UpdateForward();
        }

        private void UpdateForward()
        {
            Vector3 projCamToPlayer = Vector3.ProjectOnPlane(playerRoot.position - cameraRoot.position, Vector3.up).normalized;

            playerRoot.rotation = Quaternion.LookRotation(projCamToPlayer, Vector3.up);
        }

        private void OnMoveAction(CallbackContext ctx)
        {
            if (ctx.performed)
                shouldUpdateForward = true;
            else if(ctx.canceled)
                shouldUpdateForward = false;
        }
    }
}
