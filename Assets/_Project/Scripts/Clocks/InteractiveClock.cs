using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveClock : Clock
{
    [SerializeField] Dial _hourHand;
    [SerializeField] Dial _minuteHand;

    private int _movingDialsCount = 0;

    private void Awake()
    {
        _hourHand.selectEntered.AddListener(onDialsStartMoving);
        _minuteHand.selectEntered.AddListener(onDialsStartMoving);

        _hourHand.selectExited.AddListener(onDialsStopMoving);
        _minuteHand.selectExited.AddListener(onDialsStopMoving);
    }

    private void Update()
    {
        if (_movingDialsCount <= 0) return;

        int hours = Mathf.RoundToInt(_hourHand.GetProgress() * totalHours);
        int minutes = Mathf.FloorToInt(_minuteHand.GetProgress() * totalMinutes);

        SetTime(hours, minutes);
    }

    public override void SetTime(int pHours, int pMinutes)
    {
        base.SetTime(pHours, pMinutes);

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
