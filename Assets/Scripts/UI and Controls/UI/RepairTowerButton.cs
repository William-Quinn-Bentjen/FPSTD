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
        UpgradeScreenUI.instance.UpdateCostText(Cost);
    }
    public void ResetCostValue()
    {
        UpgradeScreenUI.instance.UpdateCostText(0);
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
