using UnityEngine;
using UnityEngine.Events;

public class ThresholdCounter : Counter
{
    [SerializeField] private int _threshold = 10;
    [SerializeField] private UnityEvent _onThresholdReached;

    private bool _isThresholdReached = false;
    
    protected override void setCount(int pCount)
    {
        if(_isThresholdReached) return;
        
        base.setCount(pCount);

        if (count < _threshold) return;
        
        _isThresholdReached = true;
        _onThresholdReached?.Invoke();
    }

    public override void Reset()
    {
        base.Reset();
        _isThresholdReached = false;
    }
}
