using DG.Tweening;
using UnityEngine;

public class DOTweenAnimator : MonoBehaviour
{
    [SerializeField] private Vector3 movement;
    [SerializeField] private float duration;

    void Start()
    {
        transform.DOMove(transform.position + movement, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
