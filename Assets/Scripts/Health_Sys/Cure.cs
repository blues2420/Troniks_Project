using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour, I_Curable
{
    public void Do_Cure(Health_System health_Sys, float amount)
    {
        health_Sys.Heal(amount);
    }
}
