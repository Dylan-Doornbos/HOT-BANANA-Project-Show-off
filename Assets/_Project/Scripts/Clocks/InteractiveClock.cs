using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveClock : Clock
{
    [SerializeField] Dial _hourHand;
    [SerializeField] Dial _minuteHand;

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
        if (_movingDialsCount <= 0) return;


        int hours = Mathf.RoundToInt(_hourHand.GetProgress() * 24);
        int minutes = Mathf.FloorToInt(_minuteHand.GetProgress() * 60);

        SetTime(hours, minutes);
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

        float hourProgress = hours / 24;
        float minuteProgress = minutes / 60;

        _hourHand.SetProgress(hourProgress);
        _minuteHand.SetProgress(minuteProgress);
    }
}
