using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTowerButton : MonoBehaviour {
    private float Cost;
    public void UpdateCost()
    {
        Cost = GameManager.instance.towerHP.maxHP - GameManager.instance.towerHP.HP;
    }
    public void SetCostValue()
    {
        UpgradeScreenUI.instance.CostText.text = Cost.ToString();
        UpgradeScreenUI.instance.LeftoverResourcesText.text = (ResourceManager.Resources - Cost).ToString();
    }
    public void ResetCostValue()
    {
        UpgradeScreenUI.instance.CostText.text = "0";
        UpgradeScreenUI.instance.LeftoverResourcesText.text = ResourceManager.Resources.ToString();
    }
    public void RepairTower()
    {
        if (Cost <= ResourceManager.Resources)
        {
            ResourceManager.Resources -= Cost;
            GameManager.instance.towerHP.SetHP(GameManager.instance.towerHP.maxHP);
        }
        else if (Cost > ResourceManager.Resources)
        {
            GameManager.instance.towerHP.Heal(ResourceManager.Resources);
            ResourceManager.Resources = 0;
        }
    }
}
