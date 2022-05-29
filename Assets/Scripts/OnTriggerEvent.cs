using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.IsPlayer()) 
            onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.IsPlayer())
            onTriggerExit.Invoke();
    }
}
