using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public static Holster GunHolster;
    //easier to 
    public Rifle rifle;
    public Shotgun shotgun;
    public Pistol handgun;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //fire selected weapon
            GunHolster.Selected.TriggerDown();
        }
        if (Input.GetButtonDown("Reload"))
        {
            //reload currently selected weapon
            GunHolster.Selected.StartReload();
        }
        if (Input.GetButtonDown("Special"))
        {
            //scope in if the selected weapon can
            if (GunHolster.Selected == shotgun)
            {
                //cancel shotgun reload
                shotgun.CancelReload();
            }
        }
        if (Input.GetButtonDown("SelectRifle"))
        {
            //switch to rifle
            GunHolster.SelectWeapon(GunHolster.Weapons[2]);
        }
        else if (Input.GetButtonDown("SelectShotgun"))
        {
            //switch to shotgun
            GunHolster.SelectWeapon(GunHolster.Weapons[1]);
        }
        else if (Input.GetButtonDown("SelectHandgun"))
        {
            //switch to handgun
            GunHolster.SelectWeapon(GunHolster.Weapons[0]);
        }
    }
}
