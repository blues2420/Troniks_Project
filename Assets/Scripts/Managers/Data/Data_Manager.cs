using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data_Manager : MonoBehaviour
{
    internal Action<int> Score_Update;
    private int score;
    private int best_Score;

    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/Score";
        Game_Events.Game_Lost += Save_Score;
        Game_Events.Game_Won += Save_Score;
        Check_Score();
    }

    private void OnDisable()
    {
        Game_Events.Game_Lost -= Save_Score;
        Game_Events.Game_Won -= Save_Score;
    }

    public void Add_Score(int amount)
    {
        score += amount;
        Score_Update?.Invoke(score);
    }

    private void Check_Score()
    {
        if (!File.Exists(path))
        {
            File.CreateText(path).Close();
            Save_Score();
        }
        else
        {
            Load_Score();
        }
    }

    public void Save_Score()
    {
        if (best_Score > score)
        {
            best_Score = score;
            string json = JsonUtility.ToJson(best_Score);
            File.WriteAllText(path, json);
        }
    }

    private void Load_Score()
    {
        string json = File.ReadAllText(path);
        best_Score = JsonUtility.FromJson<int>(json);
    }
}
