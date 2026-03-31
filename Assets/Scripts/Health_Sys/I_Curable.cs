using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Curable
{
    public void Do_Cure(Health_System health_Sys, float amount);
}
