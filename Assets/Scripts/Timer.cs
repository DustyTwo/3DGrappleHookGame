using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float totalRunTime;
    public float currentTime;
    public bool Done { get { return currentTime > totalRunTime; } private set { } }

    public Timer(float runTime, float startTime = 0)
    {
        totalRunTime = runTime;
        currentTime = startTime;
    }

    //timer += time -> add time to timer
    public static Timer operator +(Timer timer, float time)
    {
        timer.currentTime += time;
        return timer;
    }

    public void Reset()
    {
        currentTime = 0;
    }
}
