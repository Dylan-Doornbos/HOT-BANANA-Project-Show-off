using UnityEngine;
using UnityEngine.Events;

public class ClockComparer : MonoBehaviour
{
    [SerializeField] Clock _clockA;
    [SerializeField] Clock _clockB;
    [SerializeField] UnityEvent _onTimeSynced;

    private void Awake()
    {
        if (_clockA.minuteStepSize != _clockB.minuteStepSize)
        {
            DebugUtil.Log($"'{nameof(_clockA)}' and '{nameof(_clockB)}' have different '{nameof(Clock.minuteStepSize)}'. Clocks might not be able to be the same time. Source object: '{gameObject.name}'", LogType.WARNING);
        }
    }

    private void OnEnable()
    {
        _clockA.onTimeChanged.AddListener(compareClocks);
        _clockB.onTimeChanged.AddListener(compareClocks);
    }

    private void OnDisable()
    {
        _clockA.onTimeChanged.RemoveListener(compareClocks);
        _clockB.onTimeChanged.RemoveListener(compareClocks);
    }

    /// <summary>
    /// Checks if the specified clocks have the same time
    /// </summary>
    private void compareClocks()
    {
        if (_clockA.hours == _clockB.hours && _clockA.minutes == _clockB.minutes)
            _onTimeSynced?.Invoke();
    }
}
