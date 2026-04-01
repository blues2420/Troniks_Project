using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Run_State : Base_Character_State
{
    public Character_Run_State(ref Base_Character character) : base(ref character) { }

    public override void Initialize_State()
    {
        base.Initialize_State();

        List<State_Transition> transitions = new List<State_Transition>
        {
            new(character.states[Game_Strings.States.Idle], To_Idle),
            new(character.states[Game_Strings.States.Defend], To_Defend),
            new(character.states[Game_Strings.States.Attack], To_Attack)
        };
        
        character.state_Machine.Add_Transitions(character.states[Game_Strings.States.Run], transitions);
    }

    public override void Enter_State()
    {
        base.Enter_State();
        character.movement.Resume_Movement();
        character.anim.Play(Game_Strings.States.Run);
    }
    
    public override void Exit_State()
    {
        base.Exit_State();
        character.movement.Stop_Movement();
    }

    private bool To_Idle() => character.movement.move_Value == Vector2.zero;
    private bool To_Defend() => character.is_Defending;
    private bool To_Attack() => character.is_Attacking;
}
