using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DojoGameManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }

    IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            GameObject enemigo = EnemyPool.Instance.GetEnemy();
            if (enemigo != null)
            {
                enemigo.transform.position = new Vector3(-6.18f, -1.5f, 0);
            }

            GameObject enemigo2 = EnemyPool.Instance.GetEnemy();
            if (enemigo2 != null)
            {
                enemigo2.transform.position = new Vector3(4.13f, -1.5f, 0);
            }

            yield return new WaitForSeconds(3);
        }
    }
}
