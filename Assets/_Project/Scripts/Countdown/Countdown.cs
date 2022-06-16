using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Countdown : Timer
{
    [SerializeField] float _durationInSeconds = 1;
    [FormerlySerializedAs("_onTimerFinished")] [SerializeField] UnityEvent _onCountdownFinished;

    private void Awake()
    {
        _isRunning = _startImmediately;
        Reset();
    }

    protected override void tick()
    {
        if (time <= 0) return;
        
        setTime(time - Time.deltaTime);
        if (time <= 0) _onCountdownFinished?.Invoke();
    }

    public void SetDuration(float pDuration)
    {
        _durationInSeconds = pDuration;
        Reset();
    }

    public override void Reset()
    {
        Pause();
        setTime(_durationInSeconds);
    }
}