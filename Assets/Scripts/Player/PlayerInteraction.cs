using UnityEngine;
using Useables;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] private LayerMask useableLayer;
        [SerializeField] private Vector3 cameraOffset;

        private PlayerMovementInput inputActions;
        private float raycastDistance = 50;

        public void Init(PlayerMovementInput input)
        {
            inputActions = input;
            inputActions.Player.Use.performed += Use;
        }

        private void Use(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            RaycastHit hit;
            if (!Physics.Raycast(camera.position + cameraOffset, camera.forward, out hit, raycastDistance, useableLayer))
                return;

            if (hit.collider.gameObject.TryGetComponent(out IUseable useable))
                useable.Use();
        }

    }
}