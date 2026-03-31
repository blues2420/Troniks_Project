using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Prefab;
    [SerializeField] private int amount;
    [SerializeField] private int start_Amount;
    private List<GameObject> enemies;
    [SerializeField] private Transform spawn_Point;

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemy_Prefab, spawn_Point.position, Quaternion.identity);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

        Game_Events.Game_Started += Set_Enemies;
    }

    private void Set_Enemies()
    {
        for (int i = 0; i < start_Amount; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    public void Next_Enemy()
    {
        enemies.Find(x => !x.activeInHierarchy).SetActive(true);
    }
}
