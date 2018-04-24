using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Damage = 1;
    public float LifeTime = 5;
    public float LifeTimer = 0;
    public PooledObject pooledObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IDamageable>().TakeDamage(Damage);
            ReturnToPool();
        }
        if (other.tag == "Environment")
        {
            ReturnToPool();
        }
    }
	// Use this for initialization
	void Start () {
        pooledObj.myPool = BulletPool.BulletPoolInstance;
	}
	
	// Update is called once per frame
	void Update () {
        LifeTimer += Time.deltaTime;
        if(LifeTimer > LifeTime)
        {
            ReturnToPool();
        }
	}
    void ReturnToPool()
    {
        pooledObj.returnToPool();
        LifeTimer = 0;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //gameObject.GetComponent<TrailRenderer>().enabled = false;
    }
}
