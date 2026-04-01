using System;
using System.Collections;
using System.Collections.Generic;
using AwesomeAttributes;
using UnityEngine;
using Zenject;

public class CPU : MonoBehaviour
{
    [Inject] private Data_Manager data;
    [Inject] private Enemies_Spawner enemies_Spawn;
    
    private Base_Character character;
    private Transform player;

    [SerializeField, Readonly] private Vector2 dis_To_Player;
    [SerializeField, Readonly] private float dot;
    private Vector2 dir;

    [SerializeField] private Vector2 attack_Dis;
        
    private void Awake()
    {
        TryGetComponent(out character);
        player = FindFirstObjectByType<Player>().transform;
    }

    private void OnEnable()
    {
        character.die += Dead;
    }

    private void OnDisable()
    {
        character.die -= Dead;
    }

    private void Update()
    {
        dis_To_Player = transform.position - player.transform.position;
        dot = Vector2.Dot(transform.right, dis_To_Player.normalized);

        character.movement.move_Value = new Vector2(dot >= 0 ? -1 : 1, dot > 0 && dot < 0.5 ? player.transform.position.y > transform.position.y ? 1 : 0 : 0);

        if (dis_To_Player.x <= attack_Dis.x)
        {
            character.movement.move_Value = Vector2.zero;
            character.Attack(true);
        }
    }

    private void Dead()
    {
        data.Add_Score(1);
        enemies_Spawn.Next_Enemy(character);
    }
}
