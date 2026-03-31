using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Attack : MonoBehaviour, I_Attack
{
    protected Damage damage;

    protected virtual void Awake()
    {
        TryGetComponent(out damage);
    }

    public virtual void Attack() { }
    
    public virtual void Attack_End() { }
}
