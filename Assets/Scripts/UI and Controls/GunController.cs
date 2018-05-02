using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponType
{
    Pistol,
    Shotgun,
    Rifle
}
public class GunController : MonoBehaviour {
    public bool enableInput = true;
    public static Holster GunHolster;
    
    public delegate void SelectAWeapon(WeaponType selected);
    public static SelectAWeapon OnSelectWeapon;

    public Rifle rifle;
    public Shotgun shotgun;
    public Pistol handgun;
    // Use this for initialization
    void Start () {
        if (GameManager.instance.gunController == null)
        {
            GameManager.instance.gunController = this;
        }
        else
        {
            Destroy(gameObject);
        }
        OnSelectWeapon.Invoke(GunHolster.Selected.TypeOfWeapon);
        
	}
    void Update()
    {
        if (enableInput)
        {
            if (Input.GetButtonDown("Fire"))
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
                //scope in if the selected weapon can (not reloading and already scoped in
                if (GunHolster.Selected.TypeOfWeapon == WeaponType.Rifle && !GunHolster.Selected.Reloading && ReticleController.instance.SelectedWeapon != ReticleController.ReticleType.Rifle)
                {
                    ReticleController.instance.ChangeReticle(ReticleController.ReticleType.Rifle);
                }
                else if (GunHolster.Selected.TypeOfWeapon == WeaponType.Rifle && ReticleController.instance.SelectedWeapon == ReticleController.ReticleType.Rifle)
                {
                    ReticleController.instance.ChangeReticle(ReticleController.ReticleType.None);
                }
                else if (GunHolster.Selected.TypeOfWeapon == WeaponType.Shotgun && GunHolster.Selected.Reloading)
                {
                    Debug.Log("Canceled reload");
                    //cancel shotgun reload
                    shotgun.CancelReload();
                }
                //if (GunHolster.Selected == rifle && !GunHolster.Selected.Reloading)
                //{
                //    zoom in
                //}
            }
            if (Input.GetButton("SelectRifle"))
            {
                //switch to rifle
                GunHolster.SelectWeapon(GunHolster.Weapons[2]);
                OnSelectWeapon.Invoke(WeaponType.Rifle);
            }
            else if (Input.GetButton("SelectShotgun"))
            {
                //switch to shotgun
                GunHolster.SelectWeapon(GunHolster.Weapons[1]);
                OnSelectWeapon.Invoke(WeaponType.Shotgun);
            }
            else if (Input.GetButton("SelectHandgun"))
            {
                //switch to handgun
                GunHolster.SelectWeapon(GunHolster.Weapons[0]);
                OnSelectWeapon.Invoke(WeaponType.Pistol);
            }
        }
    }

}
