using UnityEngine;

public class AnalogClockDisplay : ClockDisplay
{
    [SerializeField] SingleAxisRotator _hourHand;
    [SerializeField] SingleAxisRotator _minuteHand;

    protected override void updateDisplay()
    {
        float hourProgress = _clock.hours / (float)Clock.totalHours;
        float minuteProgress = _clock.minutes / (float)Clock.totalMinutes;

        float hourAngle = 360 * hourProgress;
        float minuteAngle = 360 * minuteProgress;

        _hourHand.SetRotation(hourAngle);
        _minuteHand.SetRotation(minuteAngle);
    }
}
