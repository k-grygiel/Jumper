using DG.Tweening;
using UnityEngine;

namespace Tower
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private float time;
        private float yOffset = 0.5f;

        public void GoToFloor(Transform newPos)
        {
            DOTween.Kill(this);
            float currentYPos = transform.position.y;
            float newYPos = newPos.position.y;
            float duration = Mathf.Abs(currentYPos - newYPos) * time;
            transform.DOMoveY(newYPos + yOffset, duration).SetUpdate(UpdateType.Fixed, true);
        }
    }
}