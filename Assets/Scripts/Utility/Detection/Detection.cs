using System;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Detection_SO detection_Dic;
    public List<Dat> detections = new();

    private void Start()
    {
        Debug.Log(detection_Dic.detection_Dic.Count);
    }
    public void Set_Dictionary()
    {
        detection_Dic.Set_Dictionary(detections);
    }

    [Serializable] public struct Dat
    {
        public string detection_Name;
        public Detection_Data detection_Data;
    }
}