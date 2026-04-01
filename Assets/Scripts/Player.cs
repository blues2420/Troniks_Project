using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] protected Input_Manager inputs;
    [Inject] private Game_Manager game;

    private Base_Character character;

    [SerializeField] private InputActionReference defend_Ref;
    [SerializeField] private InputActionReference attack_Ref;

    private void Start()
    {
        Game_Events.Game_Started += Start_Player;
        game.enemy_Die += Enemy_Killed;
    }

    private void Start_Player()
    {
        TryGetComponent(out character);
        character.die += Dead;
        inputs.Subscribe(defend_Ref, InputActionPhase.Started, Defend);
        inputs.Subscribe(defend_Ref, InputActionPhase.Canceled, Cancel_Defend);
        inputs.Subscribe(attack_Ref, InputActionPhase.Started, Attack);
    }

    private void OnDisable()
    {
        Game_Events.Game_Started -= Start_Player;
        game.enemy_Die -= Enemy_Killed;
        character.die -= Dead;
        
        inputs.Unsubscribe(defend_Ref, InputActionPhase.Started, Defend);
        inputs.Unsubscribe(defend_Ref, InputActionPhase.Canceled, Cancel_Defend);
        inputs.Unsubscribe(attack_Ref, InputActionPhase.Started, Attack);
    }

    private void Update()
    {
        character.movement.move_Value = inputs.Get_Move_Value();
    }

    private void Defend(InputAction.CallbackContext ctx)
    {
        character.Defend(true);
    }
    
    private void Cancel_Defend(InputAction.CallbackContext ctx)
    {
        character.Defend(false);
    }
    
    private void Attack(InputAction.CallbackContext ctx)
    {
        character.Attack(true);
    }

    private void Dead()
    {
        game.Game_Over();
    }

    private void Enemy_Killed(Characters_Vars enemy_Vars)
    {
        character.Heal(enemy_Vars.healing_To_Player);
    }
}
