using System;
using UnityEngine;

public class State_Transition
{
    public I_Character_State New_State;
    public Func<bool> Conditions;

    public State_Transition(I_Character_State new_State, Func<bool> conditions)
    {
        New_State = new_State;
        Conditions = conditions;
    }
}
