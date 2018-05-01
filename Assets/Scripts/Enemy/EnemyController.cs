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
	void Awake () {
        Health.OnDeath = Death;
        EnemyDestination = GameManager.instance.destination.gameObject;
        agent.destination = EnemyDestination.transform.position;
        PooledObjectComponent.myPool = GameManager.instance.enemyPool; 
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
    public void ChangeStats(WaveSettings waveSetting)
    {
        Health.SetMaxHP(waveSetting.Health, true);
        agent.speed = waveSetting.Speed;
        agent.acceleration = waveSetting.Acceleration;
        Damage = waveSetting.Damage;
        TimeBetweenShots = waveSetting.TBS;
    }
    public void ReturnToPool()
    {
        TBSTimer = TimeBetweenShots;
        WaveManager.instance.RemoveEnemy(gameObject);
        Debug.Log("Enemy returned to pool");
        WaveManager.instance.RemoveEnemy(gameObject);
        PooledObjectComponent.returnToPool();
    }
    void Death()
    {
        //go back to spawn pool
        ReturnToPool();
        ResourceManager.AddKillReward();
        Debug.Log("Enemy Death");
    }
}
