using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour {
    public static ReticleController instance;
    public Image ShotgunReticle;
    public Image PistolReticle;
    public Image SniperReticle;
    public enum ReticleType
    {
        None,
        Pistol,
        Rifle,
        Shotgun
    }
    public ReticleType SelectedWeapon = ReticleType.None;
    public void ChangeReticle(ReticleType reticle)
    {
        RemoveSelectedReticle();
        if (reticle == ReticleType.Pistol)
        {
            PistolReticle.gameObject.SetActive(true);
        }
        else if (reticle == ReticleType.Shotgun)
        {
            ShotgunReticle.gameObject.SetActive(true);
        }
        else if (reticle == ReticleType.Rifle)
        {
            SniperReticle.gameObject.SetActive(true);
            Camera.main.fieldOfView = 10;
        }
        SelectedWeapon = reticle;
    }
    void RemoveSelectedReticle()
    {
        if (SelectedWeapon != ReticleType.None)
        {
            if (SelectedWeapon == ReticleType.Pistol)
            {
                PistolReticle.gameObject.SetActive(false);
            }
            else if (SelectedWeapon == ReticleType.Rifle)
            {
                SniperReticle.gameObject.SetActive(false);
                Camera.main.fieldOfView = 60;
            }
            else if (SelectedWeapon == ReticleType.Shotgun)
            {
                ShotgunReticle.gameObject.SetActive(false);
            }
            SelectedWeapon = ReticleType.None;
        }
    }
    // Use this for initialization
    void Awake () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
