using System;
using Target;
using UnityEngine;

public class EnemyRocket : Projectile, ITarget
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private float rotation = 1;
    private Action onTriggerEnter;

    private void OnEnable()
    {
        Invoke(nameof(Kill), lifetime);
    }

    public void Kill()
    {
        onTriggerEnter?.Invoke();
    }

    public void OnKill(Action onTriggerEnter)
    {
        this.onTriggerEnter = onTriggerEnter;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
        transform.Rotate(0, rotation, 0);
    }
}