using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data_Manager : MonoBehaviour
{
    private int score;
    private int best_Score;

    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/Score";
        Check_Score();
    }

    public void Add_Score(int amount)
    {
        score += amount;
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
