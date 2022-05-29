using Target;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private EnemyRocket bulletPrefab;
    [SerializeField] private Collider spawnCollider;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float spawnDelay;
    [SerializeField] private int poolSize;
    [SerializeField] private int maxPoolSize;

    private ObjectPool<EnemyRocket> pool;
    private float time;

    private void Start()
    {
        pool = new ObjectPool<EnemyRocket>(SpawnBullet, GetBullet, ReleaseBullet, DestroyBullet, false, poolSize, maxPoolSize);
    }

    public void ResetSpawner()
    {
        pool?.Clear();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time < spawnDelay)
            return;

        pool.Get();
        time = 0;
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(
            Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x),
            Random.Range(spawnCollider.bounds.min.y, spawnCollider.bounds.max.y),
            Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z)
        );
    }

    private void DestroyBullet(EnemyRocket bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void ReleaseBullet(EnemyRocket bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private EnemyRocket SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletParent);
        bullet.transform.position = GetRandomSpawnPoint();
        bullet.OnKill(() => pool.Release(bullet));
        return bullet;
    }

    private void GetBullet(EnemyRocket bullet)
    {
        bullet.transform.position = GetRandomSpawnPoint();
        bullet.gameObject.SetActive(true);
    }
}
