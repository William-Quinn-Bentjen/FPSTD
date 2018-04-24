using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public ObjectPool EnemyPool;
    public static Spawner EnemySpawner;
    public static GameObject Destination;
    public static List<GameObject> Wave = new List<GameObject>();
    public static float WaveTime = 300;
    public static float WaveTimer;
    public static int ToBeSpawned = 0;
    public static void AddEnemy(GameObject enemy)
    {
        Wave.Add(enemy);
    }
    public static void RemoveEnemy(GameObject enemy)
    {
        Wave.Remove(enemy);
        if (Wave.Count == 0)
        {
            //no enemies left
            ResourceManager.Resources += ResourceManager.WaveEliminationReward;
            Debug.Log("removed enemy");
            WaveEnd();
        }
    }
	public static void WaveStart(float time, int Enemies)
    {
        WaveTime = time;
        WaveTimer = 0;
        ToBeSpawned = Enemies;
        
    }
    public static void WaveEnd()
    {
        Debug.Log("Wave end");
        foreach(GameObject enemy in Wave)
        {
            enemy.GetComponent<PooledObject>().returnToPool();
        }
        Wave = new List<GameObject>();
        WaveTimer = 0;
        //ui pop up?
    }
    // Use this for initialization
	void FixedUpdate()
    {
        WaveTimer += Time.deltaTime;
        //checks for time limit
        if (WaveTimer >= WaveTime)
        {
            //time limit reached wave despawned
            ResourceManager.Resources += ResourceManager.TimeExpireReward;
            Debug.Log("time up" + WaveTimer + " " + WaveTime);
            WaveEnd();
        }
        //spawns enemies
        Debug.Log(ToBeSpawned);
        if (ToBeSpawned > 0)
        {
            if (EnemySpawner.Spawn())
            {
                ToBeSpawned--;
            }
        }
    }
    void Start()
    {
        WaveStart(60, 5);
    }
}
