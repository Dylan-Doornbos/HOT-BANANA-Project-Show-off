using UnityEngine;

public abstract class CountdownUI : MonoBehaviour
{
    [SerializeField] protected Countdown _countdown;

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
