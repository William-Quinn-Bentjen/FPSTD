using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreenUI : MonoBehaviour {
    public static UpgradeScreenUI instance;
    public Text CostText;
    public Text LeftoverResourcesText;
    public void UpdateCostText(float cost)
    {
        CostText.text = cost.ToString();
        LeftoverResourcesText.text = (ResourceManager.Resources - cost).ToString();
    }
    void Awake()
    {
        GameManager.instance.upgradeScreenUI = this;
        instance = this;
    }
}
