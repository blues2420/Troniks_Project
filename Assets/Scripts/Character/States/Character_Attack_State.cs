using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Attack_State : Base_Character_State
{
    private List<Base_Attack> attacks;
    private int attack_Pos;
    
    public Character_Attack_State(ref Base_Character character, List<Base_Attack> attacks_List) : base(ref character)
    {
        attacks = attacks_List;
    }
    
    public override void Initialize_State()
    {
        base.Initialize_State();
        
        List<State_Transition> transitions = new List<State_Transition>
        {
            new(character.states[Game_Strings.States.Idle], To_Idle)
        };
        
        character.state_Machine.Add_Transitions(character.states[Game_Strings.States.Attack], transitions);
    }
    
    public override void Enter_State()
    {
        base.Enter_State();
        character.attack_Ended = false;
        character.movement.Stop_Movement();
        
        attacks[attack_Pos].Attack();
        attack_Pos = attack_Pos + 1 > attacks.Count - 1 ? 0 : attack_Pos + 1;
    }
    
    private bool To_Idle() => character.attack_Ended;
}
