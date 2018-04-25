using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
    public int InMag = 5;
    public int MagSize = 5;
    //ready to fire at 0
    public float TBS = 1;
    public float TBSTimer;
    public float ReloadTime = 3;
    public float ReloadTimer;
    public bool Reloading = false;
    public bool ReloadAfterLastShot = true;
    public GameObject Modle;
    public Animation FireAnimation;
    public virtual void Fire()
    {
        TBSTimer = TBS;
        InMag--;
        FireAnimation.Play();
        if (ReloadAfterLastShot && InMag == 0)
        {
            StartReload();
        }
    }
    public virtual void TriggerDown()
    {
        if (InMag > 0)
        {
            if (TBSTimer <= 0)
            {
                Fire();
            }
        }
    }
    public virtual void Reload()
    {
        InMag = MagSize;
        TBSTimer = 0;
        Reloading = false;
    }
    public virtual void StartReload()
    {
        ReloadTimer = ReloadTime;
        Reloading = true;
    }
    //OLD PROOF OF CONCEPT CODE 
    //public enum GunType
    //{
    //    Handgun,
    //    Shotgun,
    //    BarrettM107
    //}
    //[System.Serializable]
    //public struct GunStats
    //{
    //    public GunType Type;
    //    public float RPM;
    //    public float Force;
    //    public int InMag;
    //    public int MagSize;
    //    public float Damage;
    //    public float Pellets;
    //}
    //private float RPMTimer;
    //public int CurrentGunIdx;
    //public List<GunStats> Presets = new List<GunStats>();
    //public void Fire(float force)
    //{
    //    //
    //    if (Presets[CurrentGunIdx].Type == GunType.Shotgun)
    //    {
    //        float GroupingDistance = 10;
    //        float GroupingRadius = 1;
    //        //shotgun
    //        List<Ray> rays = new List<Ray>();
    //        for (int i = 0; i < Presets[CurrentGunIdx].Pellets;i++)
    //        {
    //            Debug.DrawLine(transform.position, transform.forward * 5, Color.green);
    //            rays.Add(new Ray(transform.position, (/*transform.position +*/ (transform.forward * GroupingDistance) + (Random.insideUnitSphere * GroupingRadius))));
    //            Debug.DrawLine(transform.position, (transform.position + (transform.forward * GroupingDistance) + (Random.insideUnitSphere * GroupingRadius)), Color.red);
    //        }
    //        foreach (Ray ray in rays)
    //        {
    //            GameObject spawned = BulletPool.BulletPoolInstance.getObject(transform.position);
    //            spawned.GetComponent<Rigidbody>().AddForce(ray.direction * force);
    //            spawned.GetComponent<TrailRenderer>().Clear();
    //            RaycastHit[] hits = Physics.RaycastAll(ray);
    //            foreach (RaycastHit hit in hits)
    //            {
    //                if (hit.collider.tag == "Enemy")
    //                {
    //                    hit.collider.GetComponent<IDamageable>().TakeDamage(Presets[CurrentGunIdx].Damage);
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        GameObject spawned = BulletPool.BulletPoolInstance.getObject(transform.position);
    //        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    //        spawned.GetComponent<TrailRenderer>().Clear();
    //        Ray ray = new Ray(transform.position, transform.forward);
    //        RaycastHit[] hits = Physics.RaycastAll(ray);
    //        foreach (RaycastHit hit in hits)
    //        {
    //            if (hit.collider.tag == "Enemy")
    //            {
    //                hit.collider.GetComponent<IDamageable>().TakeDamage(Presets[CurrentGunIdx].Damage);
    //            }
    //        }
    //    }
        
    //}
    //public void TriggerDown()
    //{
    //    if (Presets[CurrentGunIdx].InMag > 0)
    //    {
    //        if (RPMTimer <= 0)
    //        {
    //            RPMTimer = 1 / (Presets[CurrentGunIdx].RPM / 60);
    //            Fire(Presets[CurrentGunIdx].Force);
    //        }
    //    }
    //}
    //void Update()
    //{
    //    //TriggerDown();
    //    RPMTimer -= Time.deltaTime;
    //    if (Input.GetButton("Fire1"))
    //    {
    //        Debug.Log("fire called");
    //        TriggerDown();
    //    }
    //}
}
