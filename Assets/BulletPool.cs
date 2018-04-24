using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    public static ObjectPool BulletPoolInstance;
	// Use this for initialization
	void Start () {
		if (BulletPoolInstance == null)
        {
            BulletPoolInstance = GetComponent<ObjectPool>();
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
