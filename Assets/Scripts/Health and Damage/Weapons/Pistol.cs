using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {
    public float Damage = 30;
    public float force = 9999;
    public override void Fire()
    {
        base.Fire();
        GameObject spawned = BulletPool.BulletPoolInstance.getObject(transform.position);
        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        spawned.GetComponent<TrailRenderer>().Clear();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<IDamageable>().TakeDamage(Damage);
            }
        }
    }
    public override void TriggerDown()
    {
        if (!Reloading)
        {
            base.TriggerDown();
        }
    }
    public override void StartReload()
    {
        if (!Reloading)
        {
            base.StartReload();
        }
    }
	void FixedUpdate () {
        TBSTimer -= Time.deltaTime;
        //Reload logic
        if (Reloading)
        {
            ReloadTimer -= Time.deltaTime;
            if (ReloadTimer <= 0)
            {
                Reload();
            }
        }
    }
}
