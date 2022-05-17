using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public static int totalHours = 12;
    public static int totalMinutes = 60;

    [field: SerializeField] public int minuteSteps { get; private set; } = 5;

    public int hours { get; private set; }
    public int minutes { get; private set; }
    public UnityEvent onTimeChanged;

    public virtual void SetTime(int pHours, int pMinutes)
    {
        //Make sure the minutes follow the specified minute step increments
        pMinutes = Mathf.RoundToInt((pMinutes / (float)minuteSteps)) * minuteSteps;

        if (pHours == totalHours) pHours = 0;
        if (pMinutes == totalMinutes) pMinutes = 0;

        //Don't update the time if it hasn't changed
        if (hours == pHours && minutes == pMinutes) return;

        hours = pHours;
        minutes = pMinutes;
        onTimeChanged?.Invoke();
    }

    private void setTime(int pHours, int pMinutes)
    {

    }

    public virtual void RandomizeTime()
    {
        int hours = Random.Range(0, totalHours);
        int minutes = Random.Range(0, totalMinutes);

        SetTime(hours, minutes);
    }
}