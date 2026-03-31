using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Damage : Damage
{
    [SerializeField] private Object_Type target_Type;
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health_System health_Sys) && health_Sys.Get_Type() == target_Type)
        {
            Do_Damage(health_Sys, damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Health_System health_Sys) && health_Sys.Get_Type() == target_Type)
        {
            Do_Damage(health_Sys, damage);
        }
    }
}
