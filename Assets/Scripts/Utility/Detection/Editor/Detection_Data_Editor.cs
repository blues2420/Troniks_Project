using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Detection_Data))]
public class Detection_Data_Editor : Editor
{
    private Detection_Data detection;
    private VisualElement data;
    
    private VisualElement Box_VE;
    private VisualElement Sphere_VE;
    private VisualElement Capsule_VE;
    private VisualElement Ray_VE;
    
    private void OnEnable()
    {
        detection = (Detection_Data) target;
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new();
        
        EnumField shape_Enum = new("Shapes");
        shape_Enum.bindingPath = nameof(detection.shape);
        root.Add(shape_Enum);
        
        data = new();
        root.Add(data);
        
        Box_VE = new();
        Box_VE.name = nameof(detection.box);
        PropertyField box_Prop = new();
        box_Prop.bindingPath = nameof(detection.box);
        Box_VE.Add(box_Prop);
        data.Add(Box_VE);
        
        Sphere_VE = new();
        Sphere_VE.name = nameof(detection.sphere);
        PropertyField sphere_Prop = new();
        sphere_Prop.bindingPath = nameof(detection.sphere);
        Sphere_VE.Add(sphere_Prop);
        data.Add(Sphere_VE);
        
        Capsule_VE = new();
        Capsule_VE.name = nameof(detection.capsule);
        PropertyField capsule_Prop = new();
        capsule_Prop.bindingPath = nameof(detection.capsule);
        Capsule_VE.Add(capsule_Prop);
        data.Add(Capsule_VE);

        Ray_VE = new();
        Ray_VE.name = nameof(detection.ray);
        PropertyField ray_Prop = new();
        ray_Prop.bindingPath = nameof(detection.ray);
        Ray_VE.Add(ray_Prop);
        data.Add(Ray_VE);

        Change_Data();

        shape_Enum.RegisterValueChangedCallback(evt =>
        {
            Change_Data();
        });
        
        return root;
    }

    void Change_Data()
    {
        SerializedProperty data_Shape = serializedObject.FindProperty(nameof(detection.shape));
        
        VisualElement box = data.Q<VisualElement>(nameof(detection.box));
        VisualElement sphere = data.Q<VisualElement>(nameof(detection.sphere));
        VisualElement capsule = data.Q<VisualElement>(nameof(detection.capsule));
        VisualElement ray = data.Q<VisualElement>(nameof(detection.ray));
        
        switch ((Detection_Shape) data_Shape.enumValueIndex)
        {
            case Detection_Shape.Box:
                box.style.display = DisplayStyle.Flex;
                sphere.style.display = DisplayStyle.None;
                capsule.style.display = DisplayStyle.None;
                ray.style.display = DisplayStyle.None;
                break;
             
            case Detection_Shape.Sphere:
                box.style.display = DisplayStyle.None;
                sphere.style.display = DisplayStyle.Flex;
                capsule.style.display = DisplayStyle.None;
                ray.style.display = DisplayStyle.None;
                break;
             
            case Detection_Shape.Capsule:
                box.style.display = DisplayStyle.None;
                sphere.style.display = DisplayStyle.None;
                capsule.style.display = DisplayStyle.Flex;
                ray.style.display = DisplayStyle.None;
                break;

            case Detection_Shape.Ray:
                box.style.display = DisplayStyle.None;
                sphere.style.display = DisplayStyle.None;
                capsule.style.display = DisplayStyle.None;
                ray.style.display = DisplayStyle.Flex;
                break;
        }
    }

    void Add_To_Data(VisualElement visual)
    {
        data = visual;
    }
}
