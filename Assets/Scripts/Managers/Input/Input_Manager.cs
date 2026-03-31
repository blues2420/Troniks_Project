using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    public InputSystem_Actions inputs;

    [SerializeField] private CursorLockMode cursor_Mode;

    private Dictionary<Guid, Dictionary<InputActionPhase, List<Action<InputAction.CallbackContext>>>> inputs_Dic =  new();

    [SerializeField] private List<InputAction> actions;

    private void Awake()
    {
        inputs = new();
        inputs.Enable();

        Change_Cursor_State(cursor_Mode);
        
        actions.Add(inputs.Player.Crouch);
        actions.Add(inputs.Player.Move);
        actions.Add(inputs.Player.Defend);
        actions.Add(inputs.Player.Attack);
        Metodo();
    }

    private void Metodo()
    {
        inputs_Dic = new();

        foreach (var action in actions)
        {
            inputs_Dic.Add(action.id, new()
            {
                { InputActionPhase.Started, new()},
                { InputActionPhase.Performed, new()},
                { InputActionPhase.Canceled, new()}
            });

            action.started += Invoke_Inputs;
            action.performed += Invoke_Inputs;
            action.canceled += Invoke_Inputs;
        }
    }

    public void Change_Cursor_State(CursorLockMode mode) => Cursor.lockState = mode;

    public Vector2 Get_Move_Value() => inputs.Player.Move.ReadValue<Vector2>();

    public void Subscribe(InputActionReference action_Ref, InputActionPhase phase, Action<InputAction.CallbackContext> func)
    {
        if (!inputs_Dic.ContainsKey(action_Ref.action.id))
        {
            Debug.LogError("Invalid Action to Subscribe"); //Hool
            return;
        }

        InputAction action = actions.Find(x => x.id == action_Ref.action.id);

        switch (phase)
        {
            case InputActionPhase.Started:
                inputs_Dic[action.id][phase].Add(func);
                break;
            
            case InputActionPhase.Performed:
                inputs_Dic[action.id][phase].Add(func);
                break;
            
            case InputActionPhase.Canceled:
                inputs_Dic[action.id][phase].Add(func);
                break;
        }
    }

    public void Unsubscribe(InputActionReference action_Ref, InputActionPhase phase, Action<InputAction.CallbackContext> func)
    {
        if (!inputs_Dic.ContainsKey(action_Ref.action.id))
        {
            Debug.LogError("Invalid Action to Unsubscribe"); //Hool
            return;
        }

        InputAction action = actions.Find(x => x.id == action_Ref.action.id);

        switch (phase)
        {
            case InputActionPhase.Started:
                inputs_Dic[action.id][phase].Remove(func);
                break;

            case InputActionPhase.Performed:
                inputs_Dic[action.id][phase].Remove(func);
                break;

            case InputActionPhase.Canceled:
                inputs_Dic[action.id][phase].Remove(func);
                break;
        }
    }

    private void Invoke_Inputs(InputAction.CallbackContext ctx)
    {
        if (!inputs_Dic.TryGetValue(ctx.action.id, out var dic_2))
        {
            Debug.LogError("Invalid Action to Invoke");
            return;
        }

        foreach (var funcs in inputs_Dic[ctx.action.id][ctx.phase])
        {
            funcs?.Invoke(ctx);
        }
    }

    private void Gameplay_Mode()
    {
        inputs.Player.Enable();
        inputs.UI.Disable();
    }
    
    private void UI_Mode()
    {
        inputs.Player.Disable();
        inputs.UI.Enable();
    }
}
