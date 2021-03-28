using System;
using TMPro;
using UnityEngine;

public class StopWatchImpl : MonoBehaviour, StopWatch
{
    [SerializeField] private TextMeshProUGUI timerTextMeshObject;

    // Update is called once per frame 
    private float elapsedRunningTime = 0f;
    private float runningStartTime = 0f;
    private float pauseStartTime = 0f;
    private float elapsedPausedTime = 0f;
    private float totalElapsedPausedTime = 0f;
    private bool isStarted = false;
    private bool isPaused = true;

    float elapsedSeconds;
    float elapsedMinutes;
    float elapsedMilliseconds;

    float milliseconds;
    float seconds;
    float minutes;

    void Update()
    {
        if (isStarted)
        {
            elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;

            UpdateTime();
            CalculateTime();
            if (milliseconds.ToString().Length < 2) return;

            timerTextMeshObject.text = (minutes.ToString("00") + " : " + seconds.ToString("00") + " : " + milliseconds.ToString().Substring(0, 2));
        }
        else if (!isStarted)
        {
            elapsedPausedTime = Time.time - pauseStartTime;
        }
    }

    private void UpdateTime()
    {
        elapsedMilliseconds = GetMilliseconds();
        elapsedSeconds = GetSeconds();
        elapsedMinutes = GetMinutes();
        milliseconds = elapsedMilliseconds * 1000;
    }

    private void CalculateTime()
    {
        if (elapsedSeconds >= 60)
        {
            seconds = elapsedSeconds % 60;
        }
        else
        {
            seconds = elapsedSeconds;
        }

        if (elapsedMinutes >= 3600)
        {
            minutes = elapsedMinutes % 3600;
        }
        else
        {
            minutes = elapsedMinutes;
        }
    }


    public void StopTimer()
    {
        elapsedRunningTime = 0f;
        runningStartTime = 0f;
        pauseStartTime = 0f;
        elapsedPausedTime = 0f;
        totalElapsedPausedTime = 0f;
        isStarted = false;
    }

    private int GetMinutes()
    {
        return (int) (elapsedRunningTime / 60f);
    }

    private int GetSeconds()
    {
        return (int) (elapsedRunningTime);
    }

    private float GetMilliseconds()
    {
        return (float) (elapsedRunningTime - Math.Truncate(elapsedRunningTime));
    }

    public void BeginTimer()
    {
        if (!isStarted)
        {
            runningStartTime = Time.time;
            isStarted = true;
        }
    }
}