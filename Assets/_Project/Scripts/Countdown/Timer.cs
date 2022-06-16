using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] protected bool _startImmediately = false;
    public event Action onTimeChanged;

    protected bool _isRunning;
    public float time = 0;

    private void Awake()
    {
        _isRunning = _startImmediately;
        Reset();
    }

    private void Update()
    {
        if (_isRunning) tick();
    }

    protected abstract void tick();
    
    public abstract void Reset();

    protected void setTime(float pTime)
    {
        time = pTime;
        onTimeChanged?.Invoke();
    }

    public void Begin()
    {
        Reset();
        Continue();
    }

    public void Continue()
    {
        _isRunning = true;
    }

    public void Pause()
    {
        _isRunning = false;
    }
}