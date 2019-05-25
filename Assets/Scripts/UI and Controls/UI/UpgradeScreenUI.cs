using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreenUI : MonoBehaviour {
    public static UpgradeScreenUI instance;
    public Image BalanceBackground;
    public Image CostBackground;
    public Color CanAffordColor;
    public Color CantAffordColor;
    public Text CostText;
    public Text LeftoverResourcesText;
    [Header("Upgrade animation")]
    public AnimationCurve fadeCurve;
    public float fadeTime = .2f;
    Color BalanceBackgroundColor;
    Color CostBackgroundColor;
    //OLD used on 1st upgrade UI screen keept in code because I'm not sure if it's used anymore because of the 1st UI getting deleted
    public void UpdateCostText(float cost)
    {
        CostText.text = cost.ToString();
        float newBal = GameManager.instance.resourceManager.Resources - cost;
        if (newBal > 0)
        {
            BalanceBackground.color = CanAffordColor;
        }
        else
        {
            BalanceBackground.color = CantAffordColor;
        }
        LeftoverResourcesText.text = (GameManager.instance.resourceManager.Resources - cost).ToString();
    }
    void Awake()
    {
        if (GameManager.instance.upgradeScreenUI == null)
        {
            GameManager.instance.upgradeScreenUI = this;
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        BalanceBackgroundColor = BalanceBackground.color;
        CostBackgroundColor = CostBackground.color;
    }
    public void BeginFadeBalanceAndCost()
    {
        StopCoroutine(FadeBalanceAndCost());
        StartCoroutine(FadeBalanceAndCost());
    }
    IEnumerator FadeBalanceAndCost()
    {
        float timer = 0;
        float curveEvaluation = 0;
        while (timer < fadeTime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
            curveEvaluation = fadeCurve.Evaluate(timer / fadeTime);
            BalanceBackground.color = new Color(BalanceBackgroundColor.r, BalanceBackgroundColor.g, BalanceBackgroundColor.b, BalanceBackgroundColor.a + (1 - BalanceBackgroundColor.a) * curveEvaluation);
            CostBackground.color = new Color(CostBackgroundColor.r, CostBackgroundColor.g, CostBackgroundColor.b, CostBackgroundColor.a + (1 - CostBackgroundColor.a) * curveEvaluation);
        }
        CostBackground.color = CostBackgroundColor;
        BalanceBackground.color = BalanceBackgroundColor;
    }

}
