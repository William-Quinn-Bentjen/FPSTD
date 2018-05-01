using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable {
    public float minHP;
    public float HP;
    public float maxHP;

    public delegate void OnDeathEvent();
    public OnDeathEvent OnDeath;
    public delegate void OnDamage(float newHP);
    public OnDamage OnTakeDamage;

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (OnTakeDamage != null)
        {
            //used to avoid null reference exceptions
            OnTakeDamage.Invoke(HP);
        }
        //used to avoid null reference exceptions
        if (OnDeath != null && HP < minHP)
        {
            OnDeath.Invoke();
        }
    }
    public void Heal(float amount)
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
    public void SetMaxHP(float newMaxHP, bool SetHPToMax = false)
    {
        maxHP = newMaxHP;
        if (SetHPToMax)
        {
            HP = maxHP;
        }
    }
}
