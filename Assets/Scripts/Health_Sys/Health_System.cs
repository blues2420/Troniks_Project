using System;
using System.Collections;
using System.Collections.Generic;
using AwesomeAttributes;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public enum Object_Type
{
    Player, Enemy, Object
}

public class Health_System : MonoBehaviour
{
    [SerializeField] private float max_Life;
    [SerializeField, Readonly] private float life;
    [SerializeField] private Object_Type type;

    public Action<float> health_Changed; 

    protected virtual void OnEnable()
    {
        life = max_Life;
    }

    public void Heal(float amount)
    {
        life = Mathf.Clamp(life + amount, 0, max_Life);
        health_Changed?.Invoke(life);
    }

    public void Damage(float amount)
    {
        life = Mathf.Clamp(life - amount, 0, max_Life);
        health_Changed?.Invoke(life);
        
        if (life <= 0) Dead();
    }

    public virtual void Dead()
    {
        gameObject.SetActive(false);
    }

    public Object_Type Get_Type() => type;
}
