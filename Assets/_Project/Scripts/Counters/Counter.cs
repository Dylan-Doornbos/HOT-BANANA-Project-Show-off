using UnityEngine;
using UnityEngine.Events;

public abstract class Counter : MonoBehaviour
{
    public UnityEvent onCounterIncreased;

    public int count { get; protected set; }

    public abstract void IncreaseCounter(int pAmount);
}
