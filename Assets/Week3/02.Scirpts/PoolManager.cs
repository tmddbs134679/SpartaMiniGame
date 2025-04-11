using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Cat catPrefab;

    private ObjectPool<GameObject> bulletPool;
    private ObjectPool<Cat> catPool;

    private void Awake()
    {
        Instance = this;
        bulletPool = new ObjectPool<GameObject>(bulletPrefab, 20);
        catPool = new ObjectPool<Cat>(catPrefab, 20);
    }

    public GameObject SpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject bullet = bulletPool.Get();
        bullet.transform.SetPositionAndRotation(position, rotation);
        return bullet;
    }

    public void DespawnBullet(GameObject bullet)
    {
        bulletPool.ReturnToPool(bullet);
    }

    public Cat SpawnCat(Vector3 position)
    {
        Cat cat = catPool.Get();
        cat.transform.position = position;
        return cat;
    }

    public void DespawnCat(Cat cat)
    {
        catPool.ReturnToPool(cat);
    }
}
