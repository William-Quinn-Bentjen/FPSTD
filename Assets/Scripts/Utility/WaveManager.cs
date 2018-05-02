using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaveSettings
{
    //would have used a struct but I liked the idea of the wave settings being able to increase themself and not creating a new wavesetting with slightly better stats
    public void IncreaseDifficulty()
    {
        EnemiesInWave += 5;
        WaveTimeLimit++;
        Speed++;
        //Acceleration++;
        Health *= 1.1f;
        Damage *= 1.25f;
        TBS *= 0.9f;
    }
    //wave settings
    public int EnemiesInWave = 1;
    public int WaveTimeLimit = 60;
    public float SpawnTime = 0.5f;
    //enemy settings
    public float Speed = 3.5f;
    public float Acceleration = 8f;
    public float Health = 100;
    //damage settings
    public float Damage = 1;
    public float TBS = 1;
}
public class WaveManager : MonoBehaviour {
    public int WaveCount = 0;
    public static WaveManager instance;
    public ObjectPool EnemyPool;
    public static Spawner EnemySpawner;
    public static GameObject Destination;
    public List<WaveSettings> Waves = new List<WaveSettings>();
    public static List<GameObject> Wave = new List<GameObject>();
    public static float WaveTime = 300;
    public static float WaveTimer;
    private float spawnTimer = 0;
    public static float spawnRate = 0.5f;
    public static int ToBeSpawned = 0;
    public static void AddEnemy(GameObject enemy)
    {
        Wave.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        Wave.Remove(enemy);
        if (Wave.Count == 0)
        {
            //no enemies left
            GameManager.instance.resourceManager.AddWaveEliminationReward();
            Debug.Log("removed enemy");
            WaveEnd();
        }
    }
	public void WaveStart()
    {
        //if it was the last wave just make it harder
        if (Waves.Count == 1)
        {
            Waves[0].IncreaseDifficulty();
        }
        if (Waves.Count >= 1)
        {
            WaveTime = Waves[0].WaveTimeLimit;
            WaveTimer = 0;
            ToBeSpawned = Waves[0].EnemiesInWave;
            spawnTimer = 0;
            spawnRate = Waves[0].SpawnTime;
            WaveCount++;
        }
        Debug.Log("WAVE " + WaveCount + " SETTINGS\nNumber Of Enemies: " + ToBeSpawned + "\nSpawn Rate: " + spawnRate + "\nWave Time Duration " + WaveTimer);
    }
    public void WaveEnd()
    {
        Debug.Log("Wave end");
        //did wave end from time limit?
        if (Wave.Count > 0)
        {
            //enemies removal from current wave (see below for why I'm using this instead of a for loop)
            while(Wave.Count > 0)
            {
                Wave[0].GetComponent<EnemyController>().ReturnToPool();
            }
            //removed becuse the enemies tell the wave manager to remove them from the pool when ReturnToPool is called now and foreach might cause problems because of it
            //foreach (GameObject enemy in Wave)
            //{
            //    enemy.GetComponent<EnemyController>().ReturnToPool();
            //}
            Wave = new List<GameObject>();
        }
        WaveTimer = 0;
        //remove wave (would have used stack but inspector doesnt want to show it and I don't want to spend time on it)
        if (Waves.Count > 1)
        {
            Waves.RemoveAt(0);
        }
        //ui pop up?
        GameManager.instance.EndWave();
    }
    // Use this for initialization
	void FixedUpdate()
    {
        WaveTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        //checks for time limit
        if (WaveTimer >= WaveTime)
        {
            //time limit reached wave despawned
            GameManager.instance.resourceManager.AddTimeReward();
            Debug.Log("time up" + WaveTimer + " " + WaveTime);
            WaveEnd();
        }
        //spawns enemies
        //Debug.Log(ToBeSpawned + "eneimes to spawn\n" + spawnTimer + @"/" + spawnRate);
        if (ToBeSpawned > 0 && spawnTimer > spawnRate)
        {
            if (EnemySpawner.Spawn())
            {
                spawnTimer = 0;
                ToBeSpawned--;
            }
        }
    }
    void Awake()
    {
        GameManager.instance.waveManager = this;
        //OLD
        instance = this;
    }
}
