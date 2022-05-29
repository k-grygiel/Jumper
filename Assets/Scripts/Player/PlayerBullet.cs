using UnityEngine;

namespace Player
{
    public class PlayerBullet : Projectile
    {
        [SerializeField] private float lifetime;

        private void OnEnable()
        {
            Destroy(gameObject, lifetime);
        }
    }
}