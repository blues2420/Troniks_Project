using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Characters_Vars", menuName = "Scriptable Objects/Character Variables")]
public class Characters_Vars : ScriptableObject
{
    [SerializeField] internal float speed;
    [SerializeField] internal float attack_Cooldown;
    [SerializeField] internal float healing_To_Player;
}
