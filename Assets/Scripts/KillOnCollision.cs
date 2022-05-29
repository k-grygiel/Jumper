using Target;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KillOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITarget target))
            target.Kill();
    }
}
