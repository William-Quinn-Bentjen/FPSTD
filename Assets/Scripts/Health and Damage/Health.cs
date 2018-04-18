using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable {
    public float minHP;
    public float HP;
    public float maxHP;

    public delegate void OnDeath();
    public OnDeath Death;
    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP < maxHP)
        {
            Death.Invoke();
        }
    }
    public void Heal(int amount)
    {
        HP += amount;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }
    public void SetHP(float newHP)
    {
        if (newHP > maxHP)
        {
            HP = maxHP;
        }
        else if (newHP < minHP)
        {
            HP = minHP;
        }
        HP = newHP;
    }
}
