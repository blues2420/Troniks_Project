using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Timer_Manager : MonoBehaviour
{
    private Dictionary<string, Timer> timers = new();

    private void OnDisable()
    {
        foreach (var timer in timers)
        {
            timer.Value.timer_Started = null;
            timer.Value.timer_Updated = null;
            timer.Value.timer_Ended = null;
        }
        
        timers.Clear();
    }

    private void Update()
    {
        foreach (var timer in timers)
        {
            timer.Value.Update();
        }
    }

    public void Create_Timer(string timer_Name, Timer_Type type, Timer_Event evt, Action func)
    {
        if (timers.ContainsKey(timer_Name)) { Add_To_Timer(timer_Name, evt, func); return;}
            
        Timer new_Timer = new();
        new_Timer.Timer_Type = type;

        switch (evt)
        {
            case Timer_Event.Start:
                new_Timer.timer_Started += func;
                break;
            
            case Timer_Event.Update:
                new_Timer.timer_Updated += func;
                break;
            
            case Timer_Event.End:
                new_Timer.timer_Ended += func;
                break;
        }
        
        timers.Add(timer_Name, new_Timer);
    }

    public void Add_To_Timer(string timer_Name, Timer_Event evt, Action func)
    {
        if (!timers.ContainsKey(timer_Name)) { return; }
        
        switch (evt)
        {
            case Timer_Event.Start:
                timers[timer_Name].timer_Started += func;
                break;
            
            case Timer_Event.Update:
                timers[timer_Name].timer_Updated += func;
                break;
            
            case Timer_Event.End:
                timers[timer_Name].timer_Ended += func;
                break;
        }
    }
    
    public void Stop_Timer(string timer_Name)
    {
        if (!timers.ContainsKey(timer_Name)) { return; }
        
        timers[timer_Name].Stop_Timer();
    }
    
    public void Remove_Fuc_Timer(string timer_Name, Timer_Event evt, Action func)
    {
        if (!timers.ContainsKey(timer_Name)) { return; }
        
        switch (evt)
        {
            case Timer_Event.Start:
                timers[timer_Name].timer_Started -= func;
                break;
            
            case Timer_Event.Update:
                timers[timer_Name].timer_Updated -= func;
                break;
            
            case Timer_Event.End:
                timers[timer_Name].timer_Ended -= func;
                break;
        }
    }

    public void Remove_Timer(string timer_Name, Timer_Event evt, Action func)
    {
        if (!timers.ContainsKey(timer_Name)) { return; }
        
        timers[timer_Name].Remove_Timer();
        
        switch (evt)
        {
            case Timer_Event.Start:
                timers[timer_Name].timer_Started -= func;
                break;
            
            case Timer_Event.Update:
                timers[timer_Name].timer_Updated -= func;
                break;
            
            case Timer_Event.End:
                timers[timer_Name].timer_Ended -= func;
                break;
        }
        
        timers.Remove(timer_Name);
    }
    
    public void time_To_Units(string timer_Name, out int mins, out int scs)
    {
        if (!timers.ContainsKey(timer_Name))
        {
            mins = 0;
            scs = 0;
            return;
        }
        
        timers[timer_Name].time_To_Units(out mins, out scs);
    }

    public void Start_Countdown(string timer_Name, float time)
    {
        if (!timers.ContainsKey(timer_Name)) { return; }
        
        timers[timer_Name].Countdown(time);
    }

    public float Timer_Time(string timer_Name)
    {
        if (!timers.ContainsKey(timer_Name)) { return -100; }

        return timers[timer_Name].T_Time;
    }
}
