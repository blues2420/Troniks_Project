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
    }

    private void Update_Score(int score)
    {
        score_Txt.text = score.ToString();
    }

    private void Update()
    {
        
    }

    private void Update_Timer()
    {
        timer.time_To_Units(game.timer_Name, out int mins, out int scs);
        timer_Txt.text = string.Format("{0:00}:{1:00}", mins, scs);
    }
}
