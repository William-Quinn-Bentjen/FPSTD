using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static ObjectPool BulletPoolInstance;
    void Awake()
    {
        BulletPoolInstance = GetComponent<ObjectPool>();
        if (BulletPoolInstance != null && GameManager.instance.bulletPool == null)
        {
            GameManager.instance.bulletPool = this;
        }
        else
        {
            Destroy(gameObject);
            throw new System.Exception("bullet pool failed to hook up to object pool properly");
        }
    }
}