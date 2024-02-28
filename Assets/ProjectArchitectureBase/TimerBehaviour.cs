using ProjectArchitectureBase.Variables;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerBehaviour : MonoBehaviour
{
    private Action onTimerFinished;
    [SerializeField] private UnityEvent onTimerFinishedEvent;
    public FloatVariable duration;
    public bool isLoop;
    public bool startTick;
    public float currentTime;
    bool _inHours = false;
    bool _inDays = false;
    public string timeString;
    public TMP_Text timeText;
    public void Init(Action _ontimerFinished, bool inHours = false, bool inDays = false)
    {
        onTimerFinished = _ontimerFinished;
        _inHours = inHours;
        _inDays = inDays;
    }
    public void SetDuration(float _duration) 
    {
        if (duration == null)
        {
            duration = new FloatVariable();
        }
        duration.Value = _duration;
    }
    public void StartTimer()
    {
        currentTime = duration.Value;
        startTick = true;
    }
    private void OnTimerFinished()
    {
        if (onTimerFinished != null)
        {
            onTimerFinished.Invoke();
        }
        if (onTimerFinishedEvent != null)
        {
            onTimerFinishedEvent.Invoke();
        }
        if (isLoop)
        {
            StartTimer();
        }
    }
    public void Update()
    {
        if (!startTick)
        {
            timeString = "";
            return;
        }
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            startTick = false;
            currentTime = 0;
            OnTimerFinished();
        }
        var ts = TimeSpan.FromSeconds(currentTime);
        if (_inDays && (float)ts.TotalDays >= 1)
        {
            timeString = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor((float)ts.TotalDays), Math.Floor((float)ts.Hours), Math.Floor((float)ts.Minutes), ts.Seconds);
        }
        if (_inHours && (float)ts.TotalHours >= 1)
        {
            timeString = string.Format("{0:00}:{1:00}:{2:00}", Math.Floor((float)ts.TotalHours), Math.Floor((float)ts.Minutes), ts.Seconds);
        }
        timeString = string.Format("{0:00}:{1:00}", Math.Floor((float)ts.TotalMinutes), ts.Seconds);
        if (timeText != null)
        {
            timeText.text = timeString;
        }
    }
    public void Pause() 
    {
        if (startTick)
        {
            startTick = false;
        }
    }
    public void Continue() 
    {
        if (currentTime > 0)
        {
            startTick = true;
        }
    }
}
