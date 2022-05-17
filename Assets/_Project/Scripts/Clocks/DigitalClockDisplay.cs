using TMPro;
using UnityEngine;

public class DigitalClockDisplay : ClockDisplay
{
    [SerializeField] TextMeshProUGUI _txtTime;

    protected override void updateDisplay()
    {
        _txtTime.text = string.Format("{0:00}:{1:00}", _clock.hours, _clock.minutes);
    }
}
