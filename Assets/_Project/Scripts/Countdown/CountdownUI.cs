using UnityEngine;

public abstract class CountdownUI : MonoBehaviour
{
    [SerializeField] protected Countdown _countdown;

    private void Start()
    {
        onCountdownTimeChanged();
    }

    private void Update()
    {
        if (_countdown.isCounting) onCountdownTimeChanged();
    }

    protected abstract void onCountdownTimeChanged();
}
