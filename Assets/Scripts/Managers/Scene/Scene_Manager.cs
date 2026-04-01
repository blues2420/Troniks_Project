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

    private Tween fade_Out, fade_In;
    private bool changing = false;

    public void Change_Scene(int scene)
    {
        if (changing) { return; }

        changing = true;
        Fade_Out(() => SceneManager.LoadScene(scene));
    }
    
    public void Change_Scene(string scene)
    {
        if (changing) { return; }

        changing = true;
        Fade_Out(() => SceneManager.LoadScene(scene));
    }

    public void Fade_Out(Action func = null)
    {
        fade_Img.raycastTarget = true;
        fade_Out = Tween.Alpha(fade_Img, 1, fade_Duration, useUnscaledTime: true).OnComplete(() =>
        {
            Time.timeScale = 1;
             func?.Invoke();
             fade_Out.Stop();
        });
    }
    
    public void Fade_In(Action func = null)
    {
        fade_In = Tween.Alpha(fade_Img, 0, fade_Duration, useUnscaledTime: true).OnComplete(() =>
        {
            fade_Img.raycastTarget = false;
            func?.Invoke();
            fade_In.Stop();
        });
    }

    public int Get_Active_Scene() => SceneManager.GetActiveScene().buildIndex;
    public string Get_Active_Scene_Name() => SceneManager.GetActiveScene().name;
}
