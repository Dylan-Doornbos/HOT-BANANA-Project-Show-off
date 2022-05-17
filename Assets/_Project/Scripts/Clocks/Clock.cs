using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    [field: SerializeField] public int minuteSteps { get; private set; } = 5;

    public int hours { get; private set; }
    public int minutes { get; private set; }
    public UnityEvent onTimeChanged;

    public void SetTime(int pHours, int pMinutes)
    {
        pMinutes = Mathf.FloorToInt((pMinutes / (float)minuteSteps)) * minuteSteps;

        hours = Mathf.Clamp(pHours, 0, 23);
        minutes = Mathf.Clamp(pMinutes, 0, 59);
        onTimeChanged?.Invoke();
    }

    public virtual void RandomizeTime()
    {
        int hours = Random.Range(0, 23);
        int minutes = Random.Range(0, 59);

        SetTime(hours, minutes);
    }
}