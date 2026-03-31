using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision_Damage))]
public class Attack_A : Base_Attack
{
    private Base_Character character;

    protected override void Awake()
    {
        character = GetComponentInParent<Base_Character>();
    }

    public override void Attack()
    {
        base.Attack();
        character.anim.Play(Game_Strings.States.Attack + "_A");
    }

    public override void Attack_End()
    {
        base.Attack_End();
        character.is_Attacking = false;
    }
}
