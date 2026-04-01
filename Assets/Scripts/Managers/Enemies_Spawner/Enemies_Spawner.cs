using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Enemies_Spawner : MonoBehaviour
{
    [Inject] private DiContainer container;
    [Inject] private Game_Manager game;
    
    private List<GameObject> enemies = new();
    [SerializeField] private Transform spawn_Point;

    private void Start()
    {
        for (int i = 0; i < game.vars.enemies_Amount; i++)
        {
            int ran_Pos = Random.Range(0, game.vars.enemies_Prefab.Count);
            GameObject ran_Enemy = game.vars.enemies_Prefab[ran_Pos];
            GameObject enemy = container.InstantiatePrefab(ran_Enemy, spawn_Point.position, Quaternion.identity, null);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

        Game_Events.Game_Started += Set_Enemies;
    }

    private void Set_Enemies()
    {
        for (int i = 0; i < game.vars.enemies_Start_Amount; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    public void Next_Enemy(Base_Character enemy)
    {
        enemies.Find(x => !x.activeInHierarchy).SetActive(true);
        game.enemy_Die?.Invoke(enemy.character_Vars);
    }
}
