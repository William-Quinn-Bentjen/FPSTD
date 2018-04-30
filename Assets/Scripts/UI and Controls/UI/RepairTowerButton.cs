using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTowerButton : MonoBehaviour {
    public float Cost;
    public void UpdateCost()
    {
        Cost = GameManager.instance.towerHP.maxHP - GameManager.instance.towerHP.HP;
    }
    public void SetCostValue()
    {
        UpgradeScreenUI.instance.CostText.text = Cost.ToString();
    }
    public void ResetCostValue()
    {
        UpgradeScreenUI.instance.CostText.text = "0";
    }
}
