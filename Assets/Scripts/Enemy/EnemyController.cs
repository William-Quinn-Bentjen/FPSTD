using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour {
    public GameObject EnemyDestination;
    public NavMeshAgent agent;
    public PooledObject PooledObjectComponent;
    public Health Health;
    public float Damage;
    public float TimeBetweenShots;
    public float TBSTimer;
	// Use this for initialization
	void Start () {
        Health.OnDeath = Death;
        EnemyDestination = Destination.instance.gameObject;
        agent.destination = EnemyDestination.transform.position;
        PooledObjectComponent.myPool = WaveManager.EnemySpawner.EnemyPool;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower")
        {
            Attack(other.GetComponent<Health>());
        }
    }
    bool Attack(Health target)
    {
        TBSTimer += Time.deltaTime;
        if (TBSTimer > TimeBetweenShots)
        {
            TBSTimer = 0;
            target.TakeDamage(Damage);
            return true;
        }
        return false;
    }
    void Death()
    {
        TBSTimer = TimeBetweenShots;
        ResourceManager.Resources += ResourceManager.KillReward;
        ResourcesUI.UpdateResources.Invoke();
        WaveManager.RemoveEnemy(gameObject);
        Debug.Log("death");
        PooledObjectComponent.returnToPool();
    }
}
