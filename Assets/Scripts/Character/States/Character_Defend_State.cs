using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Defend_State : Base_Character_State
{
    public Character_Defend_State(ref Base_Character character) : base(ref character) { }

    public override void Initialize_State()
    {
        base.Initialize_State();
        
        List<State_Transition> transitions = new List<State_Transition>
        {
            new(character.states[Game_Strings.States.Idle], To_Idle)
        };
        
        character.state_Machine.Add_Transitions(character.states[Game_Strings.States.Defend], transitions);
    }

    public override void Enter_State()
    {
        base.Enter_State();
        character.movement.Stop_Movement();
        character.anim.Play(Game_Strings.States.Defend);
    }

    public override void Exit_State()
    {
        base.Exit_State();
        character.movement.Resume_Movement();
    }

    private bool To_Idle() => !character.is_Defending;
}
