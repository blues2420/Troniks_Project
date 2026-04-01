using System.Collections;
using System.Collections.Generic;
using AwesomeAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Game_Vars", menuName = "Scriptable Objects/Game Variables")]
public class Game_Vars : ScriptableObject
{
    [SerializeField, Title("Game Vars", "Enemies")] internal int enemies_Amount;
    [SerializeField] internal int enemies_Start_Amount;
    [SerializeField] internal List<GameObject> enemies_Prefab;

    [SerializeField, Title("", "Time")] internal float round_Time;
}
