using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSliderUI : MonoBehaviour {
    public static TowerSliderUI instance;
    public static Tower tower;
    //public static Health 
    public Slider slider;
    public void SetSlider(float value)
    {
        if (value <= slider.maxValue)
        {
            if (value < slider.minValue)
            {
                slider.value = slider.minValue;
            }
            else
            {
                slider.value = value;
            }
        }
        else
        {
            //this shouldn't ever get run and is just here incase
            throw new System.Exception("UI tower health slider value " + value + " greater than max value in slider, the slider value will be changed to the max value " + slider.maxValue + " instead");
        }
    }
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        slider.maxValue = tower.HP.maxHP;
        slider.minValue = tower.HP.minHP;
        slider.value = tower.HP.HP;
        tower.HP.OnTakeDamage = SetSlider;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
