using UnityEngine;

namespace Target
{
    public class ShootingTarget : MonoBehaviour, ITarget
    {
        [field: SerializeField] public IntValue numberOfShotTargets { get; private set; }

        public virtual void Kill()
        {
            numberOfShotTargets.Value++;
            gameObject.SetActive(false);
        }
    }
}