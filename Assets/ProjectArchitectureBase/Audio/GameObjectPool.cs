using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool : MonoBehaviour
{
    [Tooltip("Prefab to shoot")]
    [SerializeField] private GameObject objectPrefab;
    private IObjectPool<GameObject> objectPool;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateProjectile,
            OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);
    }
    private GameObject CreateProjectile()
    {
        GameObject projectileInstance = Instantiate(objectPrefab);
        projectileInstance.transform.SetParent(transform, false);
        return projectileInstance;
    }
    private void OnReleaseToPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }
    private void OnGetFromPool(GameObject pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }
    private void OnDestroyPooledObject(GameObject pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }
    public void DeActivateObject(GameObject pooledObject)
    {
        objectPool.Release(pooledObject);
    }

    internal T GetObject<T>()
    {
        return objectPool.Get().GetComponent<T>();
    }
}
