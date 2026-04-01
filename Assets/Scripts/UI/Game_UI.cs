using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Game_UI : MonoBehaviour
{
    [Inject] private Data_Manager data;
    [Inject] private Game_Manager game;
    [Inject] private Timer_Manager timer;

    [SerializeField] private TextMeshProUGUI score_Txt, timer_Txt;

    private void Start()
    {
        data.Score_Update += Update_Score;
        timer.Add_To_Timer(game.timer_Name, Timer_Event.Update, Update_Timer);
    }

    private void OnDisable()
    {
        data.Score_Update -= Update_Score;
        timer.Remove_Fuc_Timer(game.timer_Name, Timer_Event.Update, Update_Timer);
    }

    private void Update_Score(int score)
    {
        score_Txt.text = score.ToString();
    }

    private void Update_Timer()
    {
        timer.time_To_Units(game.timer_Name, out int mins, out int scs);
        timer_Txt.text = string.Format("{0:00}:{1:00}", mins, scs);
    }
}
