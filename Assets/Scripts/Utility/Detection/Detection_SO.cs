using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Detection_So", menuName = "Scriptable Objects/Detection_SO")]
public class Detection_SO : ScriptableObject
{
    public Dictionary<string, Detection_Data> detection_Dic = new();

    public void Set_Dictionary(List<Detection.Dat> detection)
    {
        detection_Dic.Clear();
        foreach (var dtc in detection)
        {
            detection_Dic.Add(dtc.detection_Name, dtc.detection_Data);
        }
        Debug.Log(detection_Dic.Count);
    }
}
