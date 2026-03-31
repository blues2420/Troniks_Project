using System;
using UnityEngine;

public enum Timer_Type
{
    Countdown,
    Stopwatch
}

public enum Timer_Event
{
    Start, Update, End
}

namespace Utils
{
    public class Timer
    {
        public Timer_Type Timer_Type
        {
            get => timerType;
            set => timerType = value;
        }

        private Timer_Type timerType;

        public float T_Time
        {
            get => time;
            set => time = value;
        }

        private float time;
        private bool ended = true;

        private bool stop_Timer;

        public Action timer_Started;
        public Action timer_Updated;
        public Action timer_Ended;


        public void Update()
        {
            if (timerType == Timer_Type.Countdown && !ended && !stop_Timer)
            {
                Do_Countdown();
            }
            else if (timerType == Timer_Type.Stopwatch)
            {
                Do_Stopwatch();
            }
        }

        public void Countdown(float initial_Time)
        {
            time = initial_Time;
            stop_Timer = false;
            ended = false;
        }

        private void Do_Countdown()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timer_Updated?.Invoke();
            }
            else if (time <= 0)
            {
                ended = true;
                timer_Ended?.Invoke();
            }
        }

        private void Do_Stopwatch()
        {
            time += Time.deltaTime;
            timer_Updated?.Invoke();
        }

        public void time_To_Units(out int mins, out int scs)
        {
            mins = (int)(time / 60);
            scs = (int)(time - mins * 60f);
        }

        public void Remove_Timer()
        {
            stop_Timer = true;
            timer_Ended?.Invoke();
        }

        public void Stop_Timer()
        {
            stop_Timer = true;
        }
    }
}
