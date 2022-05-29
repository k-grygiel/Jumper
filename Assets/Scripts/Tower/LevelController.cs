using UnityEngine;
using UnityEngine.Events;

namespace Tower
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStartLevel;
        [SerializeField] private UnityEvent onEndLevel;
        [SerializeField] private UnityEvent onRestartLevel;

        public void StartLevel()
        {
            onStartLevel?.Invoke();
        }

        public void EndLevel()
        {
            onEndLevel?.Invoke();
        }

        public void RestartLevel()
        {
            onRestartLevel?.Invoke();
        }
    }
}