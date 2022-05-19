using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveClock : Clock
{
    [SerializeField] Dial _hourHand;
    [SerializeField] Dial _minuteHand;

    private int _movingDialsCount = 0;

    private void OnEnable()
    {
        _hourHand.selectEntered.AddListener(onDialsStartMoving);
        _minuteHand.selectEntered.AddListener(onDialsStartMoving);

        _hourHand.selectExited.AddListener(onDialsStopMoving);
        _minuteHand.selectExited.AddListener(onDialsStopMoving);
    }

    private void OnDisable()
    {
        _hourHand.selectEntered.RemoveListener(onDialsStartMoving);
        _minuteHand.selectEntered.RemoveListener(onDialsStartMoving);

        _hourHand.selectExited.RemoveListener(onDialsStopMoving);
        _minuteHand.selectExited.RemoveListener(onDialsStopMoving);
    }

    private void Start()
    {
        _hourHand.SetSteps(totalHours);
        _minuteHand.SetSteps(totalMinutes / minuteStepSize);
    }

    private void Update()
    {
        if (_movingDialsCount <= 0) return;

        int newHours = Mathf.RoundToInt(_hourHand.GetProgress() * totalHours);
        int newMinutes = Mathf.FloorToInt(_minuteHand.GetProgress() * totalMinutes);

        TrySetTime(newHours, newMinutes);
    }

    protected override void setTime(int pHours, int pMinutes)
    {
        base.setTime(pHours, pMinutes);

        //Update the hour and minute hand to match the current time
        _hourHand.SetProgress(hours / (float)totalHours);
        _minuteHand.SetProgress(minutes / (float)totalMinutes);
    }

    private void onDialsStartMoving(SelectEnterEventArgs pArgs)
    {
        _movingDialsCount++;
    }

    private void onDialsStopMoving(SelectExitEventArgs pArgs)
    {
        _movingDialsCount--;
    }

    public override void RandomizeTime()
    {
        base.RandomizeTime();
    }
}
