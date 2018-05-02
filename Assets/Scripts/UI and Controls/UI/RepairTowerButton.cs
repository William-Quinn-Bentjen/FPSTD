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
        GameManager.instance.upgradeScreenUI.UpdateCostText(Cost);
    }
    public void ResetCostValue()
    {
        GameManager.instance.upgradeScreenUI.UpdateCostText(0);
    }
    public void RepairTower()
    {
        if (Cost <= GameManager.instance.resourceManager.Resources)
        {
            GameManager.instance.resourceManager.Resources -= Cost;
            GameManager.instance.towerHP.SetHP(GameManager.instance.towerHP.maxHP);
        }
        else if (Cost > GameManager.instance.resourceManager.Resources)
        {
            GameManager.instance.towerHP.Heal(GameManager.instance.resourceManager.Resources);
            GameManager.instance.resourceManager.Resources = 0;
        }
        UpdateCost();
        ResourcesUI.UpdateResources.Invoke();
    }
}
