using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
    public GameObject Laser;
    public GameObject FlashLight;
    public enum UpgradeType
    {
        Magazine,
        Damage,
        ReloadSpeed,
        NumberOfPellets,
        FlashLight,
        LaserSight,
        TowerStructure
    }
    void Awake()
    {
        GameManager.instance.upgradeManager = this;
    }
    void Upgrade(UpgradeType upgrade)
    {
        if (upgrade == UpgradeType.FlashLight)
        {
            //equip flashlight
        }
        else if (upgrade == UpgradeType.LaserSight)
        {
            //equip laser sight
        }
        else if (upgrade == UpgradeType.TowerStructure)
        {
            GameManager.instance.towerHP.SetMaxHP(GameManager.instance.towerHP.maxHP * 1.1f, true);
        }
    }
    void Upgrade(WeaponType type, UpgradeType upgrade)
    {
        if (type == WeaponType.Rifle)
        {
            Rifle gun = GameManager.instance.gunController.rifle;
            if (upgrade == UpgradeType.Damage)
            {
                gun.Damage += 30;
            }
            else if (upgrade == UpgradeType.Magazine)
            {
                gun.MagSize += 1;
            }
            else if (upgrade == UpgradeType.ReloadSpeed)
            {
                gun.ReloadTime *= 0.9f;
            }
        }
        else if (type == WeaponType.Pistol)
        {
            Pistol gun = GameManager.instance.gunController.handgun;
            if (upgrade == UpgradeType.Damage)
            {
                gun.Damage += 10;
            }
            else if (upgrade == UpgradeType.Magazine)
            {
                gun.MagSize += 2;
            }
            else if (upgrade == UpgradeType.ReloadSpeed)
            {
                gun.ReloadTime *= 0.9f;
            }
        }
        else if (type == WeaponType.Shotgun)
        {
            Shotgun gun = GameManager.instance.gunController.shotgun;
            if (upgrade == UpgradeType.Damage)
            {
                gun.Damage += 15;
            }
            else if (upgrade == UpgradeType.Magazine)
            {
                gun.MagSize += 1;
            }
            else if (upgrade == UpgradeType.ReloadSpeed)
            {
                gun.ReloadTime *= 0.9f;
            }
            else if (upgrade == UpgradeType.NumberOfPellets)
            {
                gun.PelletsPerShell += 1;
            }
        }
        
    }
}
