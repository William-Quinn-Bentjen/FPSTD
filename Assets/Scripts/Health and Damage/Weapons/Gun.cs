using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float RPM;
    public float RPMTimer;
    public float force;
    public void Fire(float force)
    {
        GameObject spawned = BulletPool.BulletPoolInstance.getObject(transform.position);
        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        spawned.GetComponent<TrailRenderer>().Clear();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hit = Physics.RaycastAll(ray);
    }
    public void TriggerDown()
    {
        if (RPMTimer <= 0)
        {
            RPMTimer = 1 / (RPM / 60);
            Fire(force);
        }
    }
    void Update()
    {
        //TriggerDown();
        RPMTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("fire called");
            TriggerDown();
        }
    }
}
