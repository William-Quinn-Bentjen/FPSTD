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
        GunController.GunHolster = this;
        if (Selected != null)
        {
            SelectWeapon(Selected);
        }
        //GunController.GunHolster = this;
        //SelectWeapon(Weapons[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
