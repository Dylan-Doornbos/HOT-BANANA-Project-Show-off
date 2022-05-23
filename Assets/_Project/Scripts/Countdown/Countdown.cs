using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    [SerializeField] float _durationInSeconds = 1;
    [SerializeField] bool _startImmediately = false;
    [SerializeField] UnityEvent _onCountdownStarted;
    [SerializeField] UnityEvent _onCountdownFinished;

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
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0) _onCountdownFinished?.Invoke();
        }
    }

    public void StartCountdown()
    {
        if (!isCounting)
        {
            isCounting = true;
            _onCountdownStarted?.Invoke();
        }
    }

    public void PauseCountdown()
    {
        if(isCounting)
        {
            isCounting = false;
        }
    }

    public void Reset()
    {
        timeLeft = _durationInSeconds;
    }
}
