using System;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    [SerializeField] float _durationInSeconds = 1;
    [SerializeField] bool _startImmediately = false;
    [SerializeField] UnityEvent _onCountdownStarted;
    [SerializeField] UnityEvent _onCountdownFinished;

    public event Action onTimeChanged;

    public float timeLeft { get; private set; }
    public bool isCounting { get; private set; }

    private void Awake()
    {
        isCounting = _startImmediately;
        Reset();
    }

    private void Update()
    {
        if (isCounting && timeLeft > 0)
        {
            setTime(timeLeft - Time.deltaTime);
            if (timeLeft <= 0) _onCountdownFinished?.Invoke();
        }
    }

    public void Begin()
    {
        Reset();
        Continue();
    }

    public void Pause()
    {
        if(isCounting)
        {
            isCounting = false;
        }
    }

    public void Continue()
    {
        if(!isCounting)
        {
            isCounting = true;
        }
    }

    public void SetDuration(float pDuration)
    {
        _durationInSeconds = pDuration;
        Reset();
    }

    public void Reset()
    {
        Pause();
        setTime(_durationInSeconds);
    }

    private void setTime(float pTime)
    {
        timeLeft = pTime;
        onTimeChanged?.Invoke();
    }
}