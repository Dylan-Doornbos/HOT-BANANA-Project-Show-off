using UnityEngine;

public abstract class ClockDisplay : MonoBehaviour
{
    [SerializeField] protected Clock _clock;

    private void Awake()
    {
        _clock.onTimeChanged.AddListener(updateDisplay);
    }

    protected abstract void updateDisplay();
}
