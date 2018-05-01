using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    //variables
    public static float Resources;
    public static float KillReward = 1;
    public static float TimeExpireReward = 5;
    public static float WaveEliminationReward = 10;
    //functions
    public static void AddKillReward()
    {
        Resources += KillReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    public static void AddTimeReward()
    {
        Resources += TimeExpireReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    public static void AddWaveEliminationReward()
    {
        Resources += WaveEliminationReward;
        ResourcesUI.UpdateResources.Invoke();
    }
    void Start()
    {
        GameManager.instance.resourceManager = this;
    }
}
