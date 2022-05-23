using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public UnityEvent onCounterIncreased;

    public int count { get; protected set; }

    public void IncreaseCounter(int pAmount)
    {
        setCount(count + pAmount);
    }

    public void Reset()
    {
        setCount(0);
    }
    private void setCount(int pCount)
    {
        count = pCount;
        onCounterIncreased?.Invoke();
    }
}
