using System;
using UnityEngine;

public enum Detection_Shape
{
    Box,
    Sphere,
    Capsule,
    Ray
}

public struct Shapes_Vars
{
    [Serializable] public struct Box
    {
        public Transform box_Pos;
        public Vector3 box_Size;
        public Vector3 box_Rot;
        public LayerMask box_Layer;

        [Header("Gizmo")] public Color gizmo_Color;
    }
        
    [Serializable] public struct Sphere
    { 
        public Transform circle_Pos;
        public float circle_Radius;
        public LayerMask circle_Layer;
        
        [Header("Gizmo")] public Color gizmo_Color;
    }
        
    [Serializable] public struct Capsule
    {
        public Transform capsule_Pos;
        public Vector2 capsule_Size;
        public CapsuleDirection2D capsule_Dir;
        public LayerMask capsule_Layer;
        
        [Header("Gizmo")] public Color gizmo_Color;
    }

    [Serializable] public struct Ray
    {
        public float ray_Distance;
        public LayerMask ray_Layer;

        [Header("Gizmo")] public Color gizmo_Color;
    }
}