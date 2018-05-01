using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UpgradeOnHighlight : MonoBehaviour
{
    public float Cost;
    public int UpgradeID;
    public void SetCostValue()
    {
        UpgradeScreenUI.instance.UpdateCostText(Cost);
    }
    public void ResetCostValue()
    {
        UpgradeScreenUI.instance.UpdateCostText(0);
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    UpgradeScreenUI.instance.CostText.text = Cost.ToString();
    //    // Do something.

    //    //Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    //}
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("The cursor exited the selectable UI element.");

    //   UpgradeScreenUI.instance.CostText.text = "0";
    //}
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
