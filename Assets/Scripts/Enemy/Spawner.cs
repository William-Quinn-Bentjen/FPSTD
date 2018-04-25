using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public ObjectPool EnemyPool;
    public List<GameObject> SpawnPoints = new List<GameObject>();
    //spawn
    public bool Spawn()
    {
        GameObject spawnPoint = FindSpawn();
        if (spawnPoint != null)
        {
            //spawn thing here
            GameObject Spawned = EnemyPool.getObject(spawnPoint.transform.position);
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
            return validSpawns[Random.Range(0, validSpawns.Count - 1)];
        }
        return null;
    }
    //filters spawn points
    List<GameObject> FilterSpawns()
    {
        List<GameObject> retVal = new List<GameObject>();
        foreach (GameObject spawnPoint in SpawnPoints)
        {
            if (spawnPoint.GetComponent<UBSTriggerZone>().GetInteractors(TriggerState.All).Count < 0)
            {
                //has enemy in it, don't spawn here
            }
            else
            {
                retVal.Add(spawnPoint);
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
