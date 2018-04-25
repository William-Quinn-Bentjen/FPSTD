using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunsUI : MonoBehaviour {
    public Image Pistol;
    public Text PistolAmmo;
    public Image Shotgun;
    public Text ShotgunAmmo;
    public Image Rifle;
    public Text RifleAmmo;
    // Use this for initialization
    void Start () {
        foreach (Gun gun in GunController.GunHolster.Weapons)
        {
            gun.OnAmmoChange = UpdateAmmo;
        }
	}
    void Awake()
    {
        GunController.OnSelectWeapon = UpdateSelectedWeapon;
    }
	void UpdateSelectedWeapon(WeaponType type)
    {
        //"deselects" them all
        Pistol.color = new Color(0, Pistol.color.g, Pistol.color.b, 32);
        Shotgun.color = new Color(0, Shotgun.color.g, Shotgun.color.b, 32);
        Rifle.color = new Color(0, Rifle.color.g, Rifle.color.b, 32);
        //"selects" the weapon that was passed
        if (type == WeaponType.Pistol)
        {
            Pistol.color = new Color(256, Pistol.color.g, Pistol.color.b, 64);
        }
        else if (type == WeaponType.Shotgun)
        {
            Shotgun.color = new Color(256, Shotgun.color.g, Shotgun.color.b, 64);
        }
        else if (type == WeaponType.Rifle)
        {
            Rifle.color = new Color(256, Rifle.color.g, Rifle.color.b, 64);
        }
    }
    void UpdateAmmo(WeaponType type ,int InMag, int MagSize)
    {
        if (type == WeaponType.Pistol)
        {
            PistolAmmo.text = InMag + @"/" + MagSize;
        }
        else if (type == WeaponType.Shotgun)
        {
            ShotgunAmmo.text = InMag + @"/" + MagSize;
        }
        else if (type == WeaponType.Rifle)
        {
            RifleAmmo.text = InMag + @"/" + MagSize;
        }
        
    }
    void SelectWeapon()
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
}
