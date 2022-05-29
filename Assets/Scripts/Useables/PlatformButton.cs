using UnityEngine;

namespace Useables
{
    public class PlatformButton : MonoBehaviour, IUseable
    {
        [SerializeField] private InteractivePlatformController platformController;
        [SerializeField] private Vector3 stepSize;

        public void Use()
        {
            platformController.Turn(stepSize);
        }
    }
}