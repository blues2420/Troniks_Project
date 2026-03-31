using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Character_State : I_Character_State
{
    protected Base_Character character;
    
    protected Base_Character_State(ref Base_Character character)
    { 
        this.character = character;
    }

    public virtual void Initialize_State()
    {
    }

    public virtual void Enter_State()
    {
    }

    public virtual void Update_State()
    {
    }

    public virtual void Fixed_Update_State()
    {
    }

    public virtual void Exit_State()
    {
    }
}
