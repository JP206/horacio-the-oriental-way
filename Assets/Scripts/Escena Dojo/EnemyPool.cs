using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    [SerializeField] int cantidadPool;
    [SerializeField] GameObject enemigo;
    List<GameObject> pool = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        for (int i = 0; i < cantidadPool; i++)
        {
            GameObject enemigoInstance = Instantiate(enemigo);
            enemigoInstance.SetActive(false);
            pool.Add(enemigoInstance);
        }
    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < cantidadPool; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        return null;
    }
}
