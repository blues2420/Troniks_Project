using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data_Manager : MonoBehaviour
{
    internal Action<int> Score_Update;
    [SerializeField] internal int score;
    [SerializeField] private Data_To_Save data;

    private string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/Score";
        Debug.Log("archivo en: " + path);
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

    private void Save_Score()
    {
        Debug.Log(data.best_Score >= score);
        if (data.best_Score >= score) { return; }
        
        Debug.Log("Save");
        data.best_Score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void Load_Score()
    {
        string json = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data_To_Save>(json);
    }
}
