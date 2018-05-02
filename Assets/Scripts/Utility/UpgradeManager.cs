using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
    public GameObject Laser;
    public List<GameObject> Fires = new List<GameObject>();
    public enum UpgradeType
    {
        PistolMagazine,
        PistolDamage,
        PistolReloadSpeed,
        ShotgunMagazine,
        ShotgunDamage,
        ShotgunNumberOfPellets,
        ShotgunReloadSpeed,
        RifleMagazine,
        RifleDamage,
        RifleReloadSpeed,
        Fires,
        LaserSight,
        TowerStructure
    }
    void Start()
    {
        GameManager.instance.upgradeManager = this;
    }
    private bool UpgradedFires = false;
    private bool UpgradedLasers = false;
    public void Upgrade(UpgradeOnHighlight info)
    {
        if (PriceCheck(info.Cost) >= 0)
        {
            Upgrade(info.UpgradeID);
        }
    }
    public float PriceCheck(float cost)
    {
        return GameManager.instance.resourceManager.Resources - cost;
    }
    //used in inspector
    /*
    1 Pistol Damage
    2 Pistol Mag
    3 Pistol Reload
    4 Rifle Damage
    5 Rifle Mag
    6 Rifle Reload
    7 Shotgun Damage
    8 Shotgun Mag
    9 Shotgun Reload
    10 Shotgun Pellets
    11 Tower Structure
    //ONE TIME USES
    12 Fires
    13 Laser 
    //repair tower
    14 repair tower
    */
    public bool Upgrade(int UpgradeID)
    {
        switch(UpgradeID)
        {
            case 1:
                {
                    GameManager.instance.gunController.handgun.Damage += 10;
                    return true;                         
                }                                    
            case 2:                                  
                {                                    
                    GameManager.instance.gunController.handgun.MagSize += 2;
                    return true;                            
                }                                     
            case 3:                                   
                {                                      
                    GameManager.instance.gunController.handgun.ReloadTime *= 0.9f;
                    return true;
                }
            case 4:
                {
                    GameManager.instance.gunController.rifle.Damage += 30;
                    return true;
                }
            case 5:
                {
                    GameManager.instance.gunController.rifle.MagSize += 1;
                    return true;
                }
            case 6:
                {
                    GameManager.instance.gunController.rifle.ReloadTime *= 0.9f;
                    return true;
                }
            case 7:
                {
                    GameManager.instance.gunController.shotgun.Damage += 15;
                    return true;
                }
            case 8:
                {
                    GameManager.instance.gunController.shotgun.MagSize += 1;
                    return true;
                }
            case 9:
                {
                    GameManager.instance.gunController.shotgun.ReloadTime *= 0.9f;
                    return true;
                }
            case 10:
                {
                    GameManager.instance.gunController.shotgun.PelletsPerShell += 1;
                    return true;
                }
            case 11:
                {
                    //up tower hp
                    GameManager.instance.towerHP.SetMaxHP(GameManager.instance.towerHP.maxHP + 30, true);
                    return true;
                }
            case 12:
                {
                    //fires
                    if (UpgradedFires == false)
                    {
                        foreach(GameObject Fire in Fires)
                        {
                            Fire.SetActive(true);
                        }
                        return true;
                    }
                    return false;
                }
            case 13:
                {
                    //laser
                    if (UpgradedLasers == false)
                    {
                        Laser.SetActive(true);
                        return true;
                    }
                    return false;
                }
        }
        return false;
    }
    //was going to be used but can't be called in inspector (left anyway)
    public bool Upgrade(UpgradeType upgrade)
    {
        if (upgrade == UpgradeType.PistolDamage)
        {
            GameManager.instance.gunController.handgun.Damage += 10;
            return true;
        }
        else if (upgrade == UpgradeType.PistolMagazine)
        {
            GameManager.instance.gunController.handgun.MagSize += 2;
            return true;
        }
        else if (upgrade == UpgradeType.PistolReloadSpeed)
        {
            GameManager.instance.gunController.handgun.ReloadTime *= 0.9f;
            return true;
        }
        //shotgun
        else if (upgrade == UpgradeType.ShotgunDamage)
        {
            GameManager.instance.gunController.shotgun.Damage += 15;
            return true;
        }
        else if (upgrade == UpgradeType.ShotgunMagazine)
        {
            GameManager.instance.gunController.shotgun.MagSize += 1;
            return true;
        }
        else if (upgrade == UpgradeType.ShotgunNumberOfPellets)
        {
            GameManager.instance.gunController.shotgun.PelletsPerShell += 1;
            return true;
        }
        else if (upgrade == UpgradeType.ShotgunReloadSpeed)
        {
            GameManager.instance.gunController.shotgun.ReloadTime *= 0.9f;
            return true;
        }
        //rifle
        else if (upgrade == UpgradeType.RifleDamage)
        {
            GameManager.instance.gunController.rifle.Damage += 30;
            return true;
        }
        else if (upgrade == UpgradeType.RifleMagazine)
        {
            GameManager.instance.gunController.rifle.MagSize += 1;
            return true;
        }
        else if (upgrade == UpgradeType.RifleReloadSpeed)
        {
            GameManager.instance.gunController.rifle.ReloadTime *= 0.9f;
            return true;
        }

        //OTHER SECTION
        else if (upgrade == UpgradeType.Fires)
        {
            if (UpgradedFires == false)
            {
                foreach (GameObject Fire in Fires)
                {
                    Fire.SetActive(true);
                }
                return true;
            }
            return false;
        }
        else if (upgrade == UpgradeType.LaserSight)
        {
            if (UpgradedLasers == false)
            {
                Laser.SetActive(true);
                return true;
            }
            return false;
        }
        else if (upgrade == UpgradeType.TowerStructure)
        {
            GameManager.instance.towerHP.SetMaxHP(GameManager.instance.towerHP.maxHP * 1.1f, true);
        }
        return true;
    }
    public void Upgrade(WeaponType type, UpgradeType upgrade)
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
