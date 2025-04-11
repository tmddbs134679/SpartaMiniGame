using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> where T : Object
{
    private T prefab;
    private Queue<T> pool = new Queue<T>();
    private int currentSize;

    public ObjectPool(T prefab, int initialSize)
    {
        this.prefab = prefab;
        currentSize = initialSize;
        ExpandPool(currentSize); // 처음 초기화
    }


    public T Get()
    {
        if (pool.Count == 0)
        {
            ExpandPool(currentSize);

        }

        T obj = pool.Dequeue();
        (obj as GameObject)?.SetActive(true);
        return obj;
    }

    private void ExpandPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab);
            (obj as GameObject)?.SetActive(false);
            pool.Enqueue(obj);
        }
        currentSize += count;
    }
    public void ReturnToPool(T obj)
    {
        (obj as GameObject)?.SetActive(false);
        pool.Enqueue(obj);
    }
}
