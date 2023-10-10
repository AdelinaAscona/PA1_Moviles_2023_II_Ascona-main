using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private T prefab;
    private List<T> pool = new List<T>();

    public ObjectPool(T prefab, int initialSize)
    {
        this.prefab = prefab;

        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }

    public T GetObject()
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        // If no inactive objects are found, create a new one.
        return CreateObject();
    }

    private T CreateObject()
    {
        T obj = GameObject.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        pool.Add(obj);
        return obj;
    }
}