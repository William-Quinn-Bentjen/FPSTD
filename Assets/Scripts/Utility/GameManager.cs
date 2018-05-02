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
    public CameraController playerCamera;
    //functions
    public void PlayerDeath()
    {
        //do a thing
    }
    public void StartWave()
    {
        //camera and control changes 
        CameraController.CursorLocked(true);
        playerCamera.enableInput = true;
        gunController.enableInput = true;
        UpgradeScreen.enabled = false;
        //reload weapons and start wave
        holster.ReloadAll();
        waveManager.WaveStart();
    }
    public void EndWave()
    {
        //camera and control changes
        CameraController.CursorLocked(false);
        playerCamera.enableInput = false;
        gunController.enableInput = false;
        UpgradeScreen.enabled = true;
        //used so the repair button only calculates it's cost when the wave ends instead of whenever a mouse enters or exits the button
        upgradeScreenUI.RepairButton.UpdateCost();
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
    //note this is here just because if StartWave is called on awake or start it won't work correctly
    bool isStared = false;
    void Update()
    {
        if (!isStared)
        {
            isStared = true;
            upgradeScreenUI.enabled = false;
            StartWave();
        }
    }
}
