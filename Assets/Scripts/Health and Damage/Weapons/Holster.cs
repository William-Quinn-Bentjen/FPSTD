using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour {
    public List<Gun> Weapons = new List<Gun>();
    public Gun _selected;
    public Gun Selected
    {
        get
        {
            return _selected;
        }
        set
        {
            if (_selected != value && Weapons.Contains(value))
            {
                _selected = value;
            }
        }
    }
    public void SelectWeapon(Gun gun)
    {
        DeselectWeapon(Selected);
        if (gun.TypeOfReticle != ReticleController.ReticleType.Rifle)
        {
            ReticleController.instance.ChangeReticle(gun.TypeOfReticle);
        }
        Selected = gun;
        Selected.enabled = true;
        Selected.Modle.gameObject.SetActive(true);
    }
    void DeselectWeapon(Gun gun)
    {
        Selected.enabled = false;
        Selected.Modle.gameObject.SetActive(false);
        ReticleController.instance.ChangeReticle(ReticleController.ReticleType.None);
    }
    // Use this for initialization
    void Awake () {
        GameManager.instance.holster = this;
        GunController.GunHolster = this;
        if (Selected != null)
        {
            SelectWeapon(Selected);
        }
        //GunController.GunHolster = this;
        //SelectWeapon(Weapons[0]);
    }
    //used to make sure the player has ammo in their weapon after a new round starts
    public void ReloadAll()
    {
        foreach (Gun gun in Weapons)
        {
            gun.Reload();
        }
    }
}
