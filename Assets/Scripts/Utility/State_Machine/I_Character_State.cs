using UnityEngine;

public interface I_Character_State
{
    public void Initialize_State();
    public void Enter_State();
    public void Update_State();
    public void Fixed_Update_State();
    public void Exit_State();
}
