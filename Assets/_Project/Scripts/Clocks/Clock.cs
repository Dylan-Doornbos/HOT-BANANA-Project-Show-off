using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Clock : MonoBehaviour
{
    [SerializeField] Dial _hourHand;
    [SerializeField] Dial _minuteHand;
    [SerializeField] int _minuteSteps = 5;

    public int hours { get; private set; }
    public int minutes { get; private set; }
    public UnityEvent onTimeChanged;
    
    private int _movingDialsCount = 0;

    private void Start()
    {
        _hourHand.selectEntered.AddListener(onDialsStartMoving);
        _minuteHand.selectEntered.AddListener(onDialsStartMoving);

        _hourHand.selectExited.AddListener(onDialsStopMoving);
        _minuteHand.selectExited.AddListener(onDialsStopMoving);
    }

    private void Update()
    {
        //if (_movingDialsCount <= 0) return;

        SetTime();
        onTimeChanged?.Invoke();
    }

    private void onDialsStartMoving(SelectEnterEventArgs pArgs)
    {
        _movingDialsCount++;
    }

    private void onDialsStopMoving(SelectExitEventArgs pArgs)
    {
        _movingDialsCount--;
    }

    public void SetTime()
    {
        hours = Mathf.RoundToInt(_hourHand.GetProgress() * 24);
        DebugUtil.Log(hours.ToString(), LogType.NORMAL);
        minutes = Mathf.FloorToInt(_minuteHand.GetProgress() * 60);
        minutes = Mathf.FloorToInt((minutes / (float)_minuteSteps)) * _minuteSteps;
    }
}