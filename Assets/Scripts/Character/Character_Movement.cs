using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    private Base_Character character;
    
    public Vector2 move_Value;

    private bool can_Move;
    [SerializeField] private bool do_Flip;

    public void Initialize(Base_Character character)
    {
        this.character = character;
    }

    public void Move()
    {
        if (!can_Move) { return; }
        character.rigid.velocity = new(move_Value.x * character.character_Vars.speed, move_Value.y * character.character_Vars.speed);
        if (do_Flip) Flip();
    }

    public void Resume_Movement() => can_Move = true;

    public void Stop_Movement()
    {
        can_Move = false;
        character.rigid.velocity = new(0f, 0f);
    }

    private void Flip()
    {
        if (move_Value.x == 0) { return; }
        transform.localScale = move_Value.x > 0 ? new Vector3(1, 1) : new Vector3(-1, 1);
    }
}
