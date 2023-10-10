using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBalas : MonoBehaviour
{
    public GameObject prefab; // Prefab del objeto a instanciar.
    public int poolSize = 10; // Tamaño inicial del pool.

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        // Si no hay objetos inactivos en el pool, crea uno nuevo.
        GameObject newObj = Instantiate(prefab);
        pool.Add(newObj);
        return newObj;
    }
}
