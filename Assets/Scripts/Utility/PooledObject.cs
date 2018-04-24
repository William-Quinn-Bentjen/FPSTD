using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {
    public ObjectPool myPool;
    public void returnToPool()
    {
        gameObject.SetActive(false);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
        transform.parent = myPool.transform;
        myPool.pool.Push(gameObject);
        Debug.Log("returned to pool");
    }
}
