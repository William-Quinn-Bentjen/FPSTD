using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //decided to use this instead of trying to make everything in it static
    public static GameManager instance;
    [Header("Set by hand")]
    //UI Canvas
    public Canvas GunsAndReticles;
    public Canvas HUD;
    public Canvas UpgradeScreen;
    [Header("Auto set by components")]
    //bullet pool
    public BulletPool bulletPool;
    public ObjectPool enemyPool;
    //Tower
    public Tower tower;
    public Health towerHP;
    //spawner 
    public Spawner spawner;
    //enemy agent destination
    public Destination destination;
    //managers (mostly for reference)
    public WaveManager waveManager;
    public ResourceManager resourceManager;
    public Holster holster;
    public UpgradeManager upgradeManager;
    public GunController gunController;

    public UpgradeScreenUI upgradeScreenUI;
    //functions
    public void PlayerDeath()
    {
        //do a thing
    }
    public void StartWave()
    {
        //start wave
        CameraController.CursorLocked(true);
        waveManager.WaveStart();
    }
    public void EndWave()
    {
        CameraController.CursorLocked(false);
        waveManager.WaveEnd();
    }
    //Monobehavior functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
