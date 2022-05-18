using UnityEngine;
using UnityEngine.Events;

public class ThresholdCounter : Counter
{
    [Min(1)][SerializeField] int _target = 1;
    [SerializeField] UnityEvent _onTargetReached;

    public override void IncreaseCounter(int pAmount)
    {
        if (count >= _target) return;

        count += pAmount;
        onCounterIncreased?.Invoke();

        if (count >= _target) _onTargetReached?.Invoke();
    }
}
