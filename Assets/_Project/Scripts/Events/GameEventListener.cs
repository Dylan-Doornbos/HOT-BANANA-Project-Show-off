using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] UnityEvent _onEventRaised;

    private void OnEnable()
    {
        if (_gameEvent == null)
        {
            DebugUtil.Log($"'{GetType()}' is missing a '{typeof(GameEvent)}' on '{gameObject.name}'.", LogType.WARNING);
            return;
        }
        
        _gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        if(_gameEvent == null) return;
        
        _gameEvent.RemoveListener(this);
    }

    public void OnEventRaised()
    {
        _onEventRaised?.Invoke();
    }
}