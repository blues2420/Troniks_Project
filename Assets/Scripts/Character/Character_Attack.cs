using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Character_Attack : MonoBehaviour
{
    [SerializeField] private List<Base_Attack> attacks;
    
    private void Attack(InputAction.CallbackContext ctx)
    {
        
    }
}
