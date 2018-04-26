using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public Health HP;
    public void Death()
    {
        //gameover
        Debug.Log("Died");
        HP.HP = 100;
    }
	// Use this for initialization
	void Awake () {
        HP.OnDeath = Death;
        TowerSliderUI.tower = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
