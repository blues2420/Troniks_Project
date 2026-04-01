using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Game_Manager : MonoBehaviour
{
    [Inject] private Scene_Manager scene;
    [Inject] private Timer_Manager timer;

    internal string timer_Name = "Round_Time";
    [SerializeField] internal Game_Vars vars;
    
    internal Action<Characters_Vars> enemy_Die;
    
    private void Start()
    {
        timer.Create_Timer(timer_Name, Timer_Type.Countdown, Timer_Event.End, Game_Won);
        scene.Fade_In(Start_Game);
    }

    private void Start_Game()
    {
        Game_Events.Game_Started?.Invoke();
        timer.Start_Countdown(timer_Name, vars.round_Time);
    }

    public void Pause_Game()
    {
        Time.timeScale = 0;
    }

    public void Resume_Game()
    {
        Time.timeScale = 1;
    }

    public void Game_Won()
    {
        timer.Remove_Fuc_Timer(timer_Name, Timer_Event.End, Game_Won);
        Time.timeScale = 0;
        Game_Events.Game_Won?.Invoke();
    }

    public void Game_Over()
    {
        timer.Remove_Fuc_Timer(timer_Name, Timer_Event.End, Game_Won);
        Time.timeScale = 0;
        Game_Events.Game_Lost?.Invoke();
    }
}
