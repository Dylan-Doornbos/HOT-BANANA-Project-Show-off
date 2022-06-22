using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveClock : Clock
{
    [SerializeField] Dial _hourHand;
    [SerializeField] Dial _minuteHand;

    private int _movingDialsCount = 0;

    private void OnEnable()
    {
        _hourHand.selectEntered.AddListener(onDialStartMoving);
        _minuteHand.selectEntered.AddListener(onDialStartMoving);

        _hourHand.selectExited.AddListener(onDialStopMoving);
        _minuteHand.selectExited.AddListener(onDialStopMoving);
    }

    private void OnDisable()
    {
        _hourHand.selectEntered.RemoveListener(onDialStartMoving);
        _minuteHand.selectEntered.RemoveListener(onDialStartMoving);

        _hourHand.selectExited.RemoveListener(onDialStopMoving);
        _minuteHand.selectExited.RemoveListener(onDialStopMoving);
    }

    private void Start()
    {
        _hourHand.SetSteps(totalHours);
        _minuteHand.SetSteps(totalMinutes / minuteStepSize);
    }
    
    private void Update()
    {
        snapTime();
    }

    /// <summary>
    /// Snaps the current time to the steps IF dials are being rotated
    /// </summary>
    private void snapTime()
    {
        if (_movingDialsCount <= 0) return;

        int newHours = Mathf.RoundToInt(_hourHand.GetProgress() * totalHours);
        int newMinutes = Mathf.FloorToInt(_minuteHand.GetProgress() * totalMinutes);

        TrySetTime(newHours, newMinutes);
    }

    /// <summary>
    /// Sets the time of the clock
    /// </summary>
    /// <param name="pHours"></param>
    /// <param name="pMinutes"></param>
    protected override void setTime(int pHours, int pMinutes)
    {
        base.setTime(pHours, pMinutes);

        //Update the hour and minute hand to match the new time
        _hourHand.SetProgress(hours / (float)totalHours);
        _minuteHand.SetProgress(minutes / (float)totalMinutes);
    }

    private void onDialStartMoving(SelectEnterEventArgs pArgs)
    {
        _movingDialsCount++;
    }

    private void onDialStopMoving(SelectExitEventArgs pArgs)
    {
        _movingDialsCount--;
    }
}
