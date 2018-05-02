using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour {
    public delegate void UpdateResourcesText();
    public static UpdateResourcesText UpdateResources;
    public Text ResourceLabel;
    public string Prefix;
    public string Suffix;
    public void UpdateResourcesUI()
    {
        ResourceLabel.text = Prefix + GameManager.instance.resourceManager.Resources + Suffix;
    }
	// Use this for initialization
	void Start () {
        UpdateResources = UpdateResourcesUI;
        UpdateResourcesUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
