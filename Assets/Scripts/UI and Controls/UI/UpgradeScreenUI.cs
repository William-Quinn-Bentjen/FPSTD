using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreenUI : MonoBehaviour {
    public static UpgradeScreenUI instance;
    public RepairTowerButton RepairButton;
    public Text CostText;
    public Text LeftoverResourcesText;
    //OLD used on 1st upgrade UI screen keept in code because I'm not sure if it's used anymore because of the 1st UI getting deleted
    public void UpdateCostText(float cost)
    {
        CostText.text = cost.ToString();
        LeftoverResourcesText.text = (GameManager.instance.resourceManager.Resources - cost).ToString();
    }
    void Awake()
    {
        if (GameManager.instance.upgradeScreenUI == null)
        {
            GameManager.instance.upgradeScreenUI = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
