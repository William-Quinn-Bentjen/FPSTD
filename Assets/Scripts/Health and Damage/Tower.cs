using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public Health HP;
    public void Death()
    {
        GameManager.instance.PlayerDeath();
        //OLD
        //gameover
        Debug.Log("Died");
        HP.HP = 100;
    }
	// Use this for initialization
	void Awake () {
        HP.OnDeath = Death;
        if (GameManager.instance.tower == null)
        {
            GameManager.instance.tower = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (GameManager.instance.towerHP == null)
        {
            GameManager.instance.towerHP = GetComponent<Health>();
        }
        else
        {
            Destroy(gameObject);
        }
        
        //OLD
        if (TowerSliderUI.tower == null)
        {
            TowerSliderUI.tower = this;
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
