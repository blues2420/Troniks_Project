using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Detection_Data : MonoBehaviour
{
    public Detection_Shape shape;
    
    public Shapes_Vars.Box box;
    public Shapes_Vars.Sphere sphere;
    public Shapes_Vars.Capsule capsule;
    public Shapes_Vars.Ray ray;

    private Ray ray_To_Draw;

    public Collider2D[] Detect()
    {
        Collider2D[] detection = new Collider2D[] { new() };

        switch (shape)
        {
            case Detection_Shape.Box:
                detection = Physics2D.OverlapBoxAll(box.box_Pos.position, box.box_Size, box.box_Layer);
                break;
            
            case Detection_Shape.Sphere:
                detection = Physics2D.OverlapCircleAll(sphere.circle_Pos.position, sphere.circle_Radius, sphere.circle_Layer);
                break;
            
            case Detection_Shape.Capsule:
                detection = Physics2D.OverlapCapsuleAll(capsule.capsule_Pos.position, capsule.capsule_Size, capsule.capsule_Dir, capsule.capsule_Layer);
                break;
        }

        return detection;
    }

    public bool Detect_Boolean()
    {
        bool detection = false;
        
        switch (shape)
        {
            case Detection_Shape.Box:
                return Physics2D.OverlapBox(box.box_Pos.position, box.box_Size, 0, box.box_Layer);

            case Detection_Shape.Sphere:
                return Physics2D.OverlapCircle(sphere.circle_Pos.position, sphere.circle_Radius, sphere.circle_Layer);

            case Detection_Shape.Capsule:
                return Physics2D.OverlapCapsule(capsule.capsule_Pos.position, capsule.capsule_Size, capsule.capsule_Dir, capsule.capsule_Layer);
        }

        return detection;
    }

    public RaycastHit2D Detect_Ray(Ray ray)
    {
        ray_To_Draw = ray;
        return Physics2D.Raycast(ray.origin, ray.direction, this.ray.ray_Distance, this.ray.ray_Layer);
    }

    public RaycastHit2D Detect_Ray(Vector3 origin, Vector3 Dir)
    {
        ray_To_Draw = new();
        ray_To_Draw.origin = origin;
        ray_To_Draw.direction = Dir;
        return Physics2D.Raycast(origin, Dir,this.ray.ray_Distance, this.ray.ray_Layer);
    }

    public void OnDrawGizmos()
    {
        switch (shape)
        {
            case Detection_Shape.Box:
                Gizmos.color = box.gizmo_Color;
                Gizmos.DrawWireCube(box.box_Pos.position, box.box_Size);
                break;
            
            case Detection_Shape.Sphere:
                Gizmos.color = sphere.gizmo_Color;
                Gizmos.DrawWireSphere(sphere.circle_Pos.position, sphere.circle_Radius);
                break;
            
            case Detection_Shape.Capsule:
                Gizmos.color = capsule.gizmo_Color;
                
                Gizmos.DrawWireSphere(capsule.capsule_Pos.position, capsule.capsule_Size.x/2);
                
                Vector3 cube_Pos = new(capsule.capsule_Pos.position.x,
                    capsule.capsule_Pos.position.y/2,
                    capsule.capsule_Pos.position.z);

                Vector3 cube_Size = new(capsule.capsule_Size.y, 
                    capsule.capsule_Pos.position.y - capsule.capsule_Size.y,
                    capsule.capsule_Size.y);
                
                Gizmos.DrawWireCube(cube_Pos, cube_Size);
                
                Gizmos.DrawWireSphere(capsule.capsule_Size, capsule.capsule_Size.x/2);
                break;

            case Detection_Shape.Ray:
                Gizmos.color = ray.gizmo_Color;
                Gizmos.DrawRay(ray_To_Draw.origin, ray_To_Draw.direction * ray.ray_Distance);
                break;
        }
    }
}
