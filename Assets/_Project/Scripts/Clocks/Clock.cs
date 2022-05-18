using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public static int totalHours = 12;
    public static int totalMinutes = 60;

    [field: SerializeField] public int minuteStepSize { get; private set; } = 5;

    public int hours { get; private set; }
    public int minutes { get; private set; }
    public UnityEvent onTimeChanged;

    public void TrySetTime(int pHours, int pMinutes)
    {
        //Make sure the minutes follow the specified minute step increments
        pMinutes = Mathf.RoundToInt((pMinutes / (float)minuteStepSize)) * minuteStepSize;

        if (pHours == totalHours) pHours = 0;
        if (pMinutes == totalMinutes) pMinutes = 0;

        //Only update the time if it changed
        if (hours != pHours || minutes != pMinutes) setTime(pHours, pMinutes);
    }

    protected virtual void setTime(int pHours, int pMinutes)
    {
        hours = pHours;
        minutes = pMinutes;
        onTimeChanged?.Invoke();
    }

    public virtual void RandomizeTime()
    {
        int hours = Random.Range(0, totalHours);
        int minutes = Random.Range(0, totalMinutes);

        TrySetTime(hours, minutes);
    }
}