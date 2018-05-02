using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    void Start()
    {
        ObjectPool EnemyPoolInstance = GetComponent<ObjectPool>();
        if (EnemyPoolInstance != null && GameManager.instance.enemyPool == null)
        {
            GameManager.instance.enemyPool = EnemyPoolInstance;
        }
        else
        {
            Destroy(gameObject);
            throw new System.Exception("enemy pool failed to hook up to object pool properly");
        }
    }
}
