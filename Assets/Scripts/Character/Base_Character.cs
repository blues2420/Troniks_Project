using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(State_Machine))]
public class Base_Character : Health_System
{
    [Inject] private Timer_Manager timer;
    
    internal Rigidbody2D rigid;
    internal Animator anim;
    internal SpriteRenderer spr_Renderer;

    [SerializeField] internal Characters_Vars character_Vars;
    
    internal State_Machine state_Machine;
    internal Character_Movement movement;

    internal Dictionary<string, I_Character_State> states;

    internal bool is_Defending;
    internal bool can_Attack = true;
    internal bool is_Attacking;
    internal bool attack_Ended = true;
    [SerializeField] private List<Base_Attack> attacks;

    protected Action die;
    

    protected override void Awake()
    {
        Initialize_Components();
        Initialize_State_Machine();
        
        timer.Create_Timer(nameof(is_Attacking), Timer_Type.Countdown, Timer_Event.End, Attack_Available);
    }
    
    protected virtual void FixedUpdate()
    {
        movement.Move();
    }
    
    protected virtual void Initialize_Components()
    {
        TryGetComponent(out rigid);
        TryGetComponent(out anim);
        spr_Renderer = GetComponentInChildren<SpriteRenderer>();
        
        TryGetComponent(out state_Machine);
        TryGetComponent(out movement);
        movement.Initialize(this);
    }

    protected virtual void Initialize_State_Machine()
    {
        Base_Character character = this;

        states = new Dictionary<string, I_Character_State>
        {
            { Game_Strings.States.Idle, new Character_Idle_State(ref character) },
            { Game_Strings.States.Run, new Character_Run_State(ref character) },
            { Game_Strings.States.Defend, new Character_Defend_State(ref character) },
            { Game_Strings.States.Attack, new Character_Attack_State(ref character, attacks) }
        };

        foreach (var state in states)
        {
            state.Value.Initialize_State();
        }
        state_Machine.Set_State(states[Game_Strings.States.Idle]);
    }
    
    public virtual void Defend(bool defending) => is_Defending = defending;

    public virtual void Attack(bool attacking)
    {
        if (!can_Attack || !attack_Ended) { return; }
        
        is_Attacking = attacking;
        if (is_Attacking)
        {
            timer.Start_Countdown(nameof(is_Attacking), character_Vars.attack_Cooldown);
            can_Attack = false;
        }
    }

    private void Attack_Available() => can_Attack = true;

    public void Attack_End()
    {
        attack_Ended = true;
        is_Attacking = false;
    }

    public override void Dead()
    {
        die?.Invoke();
        base.Dead();
    }
}
