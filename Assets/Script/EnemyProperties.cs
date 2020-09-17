﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public float health;
    public float damage;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
