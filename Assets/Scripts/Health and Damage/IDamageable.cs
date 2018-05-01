﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    void TakeDamage(float amount);
    void Heal(float amount);
    void SetHP(float HP);
}
