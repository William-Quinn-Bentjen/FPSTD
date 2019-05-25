using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour {
    public GameObject EnemyDestination;
    public Animator animator;
    public NavMeshAgent agent;
    public PooledObject PooledObjectComponent;
    public Health Health;
    public float attackRange;
    public float ReturnToPoolTime;
    public float Damage;
    public float TimeBetweenShots;
    public float TBSTimer;
    private static Health tower;
    private bool Alive
    {
        get { return Health.HP > 0; }
    }
	// Use this for initialization
	void Awake () {
        Health.OnDeath = Death;
        EnemyDestination = GameManager.instance.destination.gameObject;
        agent.destination = EnemyDestination.transform.position;
        PooledObjectComponent.myPool = GameManager.instance.enemyPool; 
        if (tower == null)
        {
            tower = FindObjectOfType<Tower>().HP;
        }
        animator.SetTrigger("Run");
    }
	
	// Update is called once per frame
	void Update () {
        if (Alive && Vector3.Distance(transform.position, GameManager.instance.destination.transform.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
            TBSTimer += Time.deltaTime;
            if (TBSTimer > TimeBetweenShots)
            {
                TBSTimer = 0;
                tower.TakeDamage(Damage);
            }
        }
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
        animator.SetTrigger("Run");
        TBSTimer = TimeBetweenShots;
        WaveManager.instance.RemoveEnemy(gameObject);
        Debug.Log("Enemy returned to pool");
        WaveManager.instance.RemoveEnemy(gameObject);
        PooledObjectComponent.returnToPool();
    }
    void Death()
    {
        agent.ResetPath();
        animator.SetTrigger("Killed");
        //go back to spawn pool
        Invoke("ReturnToPool", ReturnToPoolTime);
        GameManager.instance.resourceManager.AddKillReward();
        Debug.Log("Enemy Death");
    }
}
