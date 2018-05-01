using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public List<GameObject> SpawnPoints = new List<GameObject>();
    //spawn
    public bool Spawn()
    {
        GameObject spawnPoint = FindSpawn();
        if (spawnPoint != null)
        {
            GameObject Spawned = GameManager.instance.enemyPool.getObject(spawnPoint.transform.position);
            EnemyController enemy = Spawned.GetComponent<EnemyController>();
            enemy.ChangeStats(WaveManager.instance.Waves[0]);
            enemy.agent.destination = GameManager.instance.destination.transform.position;
            WaveManager.AddEnemy(Spawned);
            return true;
        }
        return false;
    }
    //picks a spawn
    public GameObject FindSpawn()
    {
        List<GameObject> validSpawns = FilterSpawns();
        if (validSpawns.Count > 0)
        {
            return validSpawns[Random.Range(0, validSpawns.Count)];
        }
        return null;
    }
    //filters spawn points
    List<GameObject> FilterSpawns()
    {
        List<GameObject> retVal = new List<GameObject>();
        foreach (GameObject spawnPoint in SpawnPoints)
        {
            //used to debug spawn points (disable ones that you dont want things to spawn at)
            if (spawnPoint.activeSelf)
            {
                if (spawnPoint.GetComponent<UBSTriggerZone>().GetInteractors(TriggerState.All).Count > 1)
                {
                    Debug.Log("has enemy");
                    //has enemy in it, don't spawn here
                }
                else
                {
                    retVal.Add(spawnPoint);
                }
            }
        }
        if (retVal.Count > 0)
        {
            return retVal;
        }
        return new List<GameObject>();
    }
	// Use this for initialization
	void Awake () {
        WaveManager.EnemySpawner = this;
        GameManager.instance.spawner = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
