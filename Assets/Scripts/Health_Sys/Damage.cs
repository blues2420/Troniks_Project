using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, I_Damagable
{
    public void Do_Damage(Health_System health_Sys, float amount)
    {
        health_Sys.Damage(amount);
    }
}
