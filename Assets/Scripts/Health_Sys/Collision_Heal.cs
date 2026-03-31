using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Heal : Cure
{
    [SerializeField] private Object_Type target_Type;
    [SerializeField] private float heal;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Health_System health_Sys) && health_Sys.Get_Type() == target_Type)
        {
            Do_Cure(health_Sys, heal);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Health_System health_Sys) && health_Sys.Get_Type() == target_Type)
        {
            Do_Cure(health_Sys, heal);
        }
    }
}
