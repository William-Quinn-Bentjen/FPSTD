using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    //variables
    public float Resources;
    public float KillReward = 1;
    public float TimeExpireReward = 5;
    public float WaveEliminationReward = 10;
    //functions
    public void AddKillReward()
    {
        Resources += KillReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    public void AddTimeReward()
    {
        Resources += TimeExpireReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    public void AddWaveEliminationReward()
    {
        Resources += WaveEliminationReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    void Start()
    {
        GameManager.instance.resourceManager = this;
    }
}
