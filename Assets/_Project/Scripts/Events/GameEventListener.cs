using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] UnityEvent _onEventRaised;

    private void OnEnable()
    {
        _gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        _gameEvent.RemoveListener(this);
    }

    public void OnEventRaised()
    {
        _onEventRaised?.Invoke();
    }
}
