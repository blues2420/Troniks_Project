using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] private Image fade_Img;
    [SerializeField] private float fade_Duration;

    private bool changing = false;

    public void Change_Scene(int scene)
    {
        if (changing) { return; }

        changing = true;
        Fade_Out(() => SceneManager.LoadScene(scene));
    }

    public void Fade_Out(Action func = null)
    {
        fade_Img.raycastTarget = true;
        // Tween.Alpha(fade_Img, 1, fade_Duration).OnComplete(() =>
        // {
        //     Time.timeScale = 1;
        //     func?.Invoke();
        //     
        // });
    }
    
    public void Fade_In(Action func = null)
    {
    }
}
