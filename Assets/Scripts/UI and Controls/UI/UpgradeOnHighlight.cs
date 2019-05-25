using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeOnHighlight : MonoBehaviour
{
    public float Cost;
    public int UpgradeID;
    public UpgradeManager.UpgradeType upgrade;
    public void SetCostValue()
    {
        GameManager.instance.upgradeScreenUI.UpdateCostText(Cost);
    }
    public void ResetCostValue()
    {

        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        GameManager.instance.upgradeScreenUI.UpdateCostText(0);
    }
    public void AttemptUpgrade()
    {
        float newBal = GameManager.instance.resourceManager.Resources - Cost;
        //newbal is evaluated first so upgrade will only be called if they can actually afford it 
        if (newBal > 0 && GameManager.instance.upgradeManager.Upgrade(UpgradeID))
        {
            //they will only be charged if they can buy it and the upgrade was successful
            UpgradeScreenUI.instance.BeginFadeBalanceAndCost();
            GameManager.instance.resourceManager.Resources = newBal;
            ResourcesUI.Instance.UpdateResourcesUI();
            SetCostValue();
        }
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
}
