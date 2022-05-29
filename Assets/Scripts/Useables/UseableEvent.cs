using UnityEngine;
using UnityEngine.Events;

namespace Useables
{
    public class UseableEvent : MonoBehaviour, IUseable
    {
        [SerializeField] private UnityEvent onUse;

        public void Use()
        {
            onUse.Invoke();
        }
    }
}