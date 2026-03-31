using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_B : Base_Attack
{
    private Base_Character character;

    protected override void Awake()
    {
        character = GetComponentInParent<Base_Character>();
    }

    public override void Attack()
    {
        base.Attack();
        character.anim.Play(Game_Strings.States.Attack + "_B");
    }
    
    public override void Attack_End()
    {
        base.Attack_End();
        character.Attack(false);
    }
}
