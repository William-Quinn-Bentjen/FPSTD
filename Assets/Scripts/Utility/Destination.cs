using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {
    public static Destination instance;
	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
