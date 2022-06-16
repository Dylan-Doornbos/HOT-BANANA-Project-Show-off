using System;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private bool _startActive = true;
    public UnityEvent onCounterIncreased;

    public int count { get; protected set; }
    private bool _isCounting;


    private void Awake()
    {
        _isCounting = _startActive;
    }

    public void IncreaseCounter(int pAmount)
    {
        if (_isCounting) setCount(count + pAmount);
    }

    public virtual void Reset()
    {
        setCount(0);
    }

    protected virtual void setCount(int pCount)
    {
        count = pCount;
        onCounterIncreased?.Invoke();
    }

    public void ContinueCounting()
    {
        _isCounting = true;
    }

    public void StopCounting()
    {
        _isCounting = false;
    }
}