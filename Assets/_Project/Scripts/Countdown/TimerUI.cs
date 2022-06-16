using UnityEngine;

public abstract class TimerUI : MonoBehaviour
{
    [SerializeField] protected Timer _countdown;

    private void Start()
    {
        updateUI();
    }

    private void OnEnable()
    {
        _countdown.onTimeChanged += updateUI;
    }

    private void OnDisable()
    {
        _countdown.onTimeChanged -= updateUI;
    }

    protected abstract void updateUI();
}
