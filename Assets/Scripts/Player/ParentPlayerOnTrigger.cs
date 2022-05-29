using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class ParentPlayerOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.IsPlayer())
                other.gameObject.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.IsPlayer())
                other.gameObject.transform.SetParent(null);
        }
    }
}