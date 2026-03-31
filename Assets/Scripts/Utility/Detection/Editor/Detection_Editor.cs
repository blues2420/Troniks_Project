// using UnityEditor;
// using UnityEditor.UIElements;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// [CustomEditor(typeof(Detection))]
// public class Detection_Editor : Editor
// {
//     [SerializeField] Detection detection;
//
//     private void OnEnable()
//     {
//         detection = (Detection)target;
//     }
//
//     public override VisualElement CreateInspectorGUI()
//     {
//         VisualElement v_Base = new();
//
//         PropertyField so = new();
//         so.bindingPath = nameof(detection.detection_Dic);
//         v_Base.Add(so);
//
//         PropertyField list = new();
//         list.bindingPath = nameof(detection.detections);
//         v_Base.Add(list);
//
//         Button names = new();
//         names.name = "Set_Names";
//         names.text = "Set Detections Names";
//         names.RegisterCallback<ClickEvent>(delegate
//         {
//             detection.Set_Dictionary();
//         });
//         v_Base.Add(names);
//
//         return v_Base;
//     }
// }
