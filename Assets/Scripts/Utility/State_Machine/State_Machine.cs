using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class State_Machine : MonoBehaviour
{
    I_Character_State current_State;

    Dictionary<I_Character_State, List<State_Transition>> transitions = new();
    List<State_Transition> any_transitions = new();

    public void Add_Transitions(Dictionary<I_Character_State, List<State_Transition>> transitions, List<State_Transition> any_transitions)
    {
        this.transitions = transitions;
        this.any_transitions = any_transitions;
    }
    
    public void Add_Transitions(I_Character_State state, List<State_Transition> state_transitions)
    {
        if (transitions.ContainsKey(state))
        {
            transitions[state].AddRange(state_transitions);
            return;
        }
        
        transitions.Add(state, state_transitions);
    }

    public void Set_State(I_Character_State new_State)
    {
        if (new_State == current_State) { return; }

        current_State?.Exit_State();
        new_State.Enter_State();
        current_State = new_State;
    }

    private void Update()
    {
        Debug.Log(current_State);
        current_State?.Update_State();
        Check_Any_Transitions();
        Check_State_Transitions();
    }

    private void FixedUpdate()
    {
        current_State?.Fixed_Update_State();
    }

    private void Check_Any_Transitions()
    {
        foreach (var cond in any_transitions)
        {
            if (cond.Conditions())
            {
                Set_State(cond.New_State);
                return;
            }
        }
    }

    private void Check_State_Transitions()
    {
        if (current_State == null) { return; }

        if (transitions.ContainsKey(current_State)) 
        {
            foreach (var cond in transitions[current_State])
            {
                if (cond.Conditions())
                {
                    Set_State(cond.New_State);
                    return;
                }
            }
        }
    }

    public I_Character_State Get_State() => current_State;
}
