using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class AddForceOnTrigger : MonoBehaviour
    {
        [SerializeField] private float force;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.IsPlayer())
                return;

            Rigidbody rb;
            if (other.gameObject.TryGetComponent(out rb))
                rb.velocity = Vector3.up * force;
        }
    }
}