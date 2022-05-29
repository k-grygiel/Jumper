using UnityEngine;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform gun;
        [SerializeField] private Transform camera;
        [SerializeField] private Projectile projectile;
        [SerializeField] private float shootForce;
        [SerializeField] private Transform projectileContainer;

        private PlayerMovementInput inputActions;

        public void Init(PlayerMovementInput input)
        {
            inputActions = input;
            inputActions.Player.Fire.performed += Fire;
        }

        private void Fire(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            var projectile = Instantiate(this.projectile, gun.position, camera.rotation, projectileContainer);
            var rb = projectile.GetComponent<Rigidbody>();

            Vector3 shootDirection = camera.forward;
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit, 100f))
            {
                shootDirection = (hit.point - gun.position).normalized;
            }

            var force = shootDirection * shootForce + transform.up;
            rb.AddForce(force, ForceMode.Impulse);
        }


    }
}