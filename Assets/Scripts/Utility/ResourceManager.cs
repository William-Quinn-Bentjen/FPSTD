using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    private static float _resources;
    public static float Resources
    {
        get
        {
            return _resources;
        }
        set
        {
            if (_resources != value)
            {

            }
            _resources = value;
        }
    }
    public static float KillReward = 1;
    public static float TimeExpireReward = 5;
    public static float WaveEliminationReward = 10;
}
