using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event", fileName = "New Event")]
public class GameEvent : ScriptableObject
{
    [SerializeField] private List<GameEvent> _chainedEvents;
    
    [NonSerialized] private List<IGameEventListener> _listeners = new List<IGameEventListener>();
    [NonSerialized] private List<Action> _actions = new List<Action>();

    public void Raise()
    {
        foreach (GameEvent gameEvent in _chainedEvents)
        {
            if(gameEvent == this) continue;
            
            try
            {
                gameEvent.Raise();
            }
            catch (Exception e)
            {
                DebugUtil.Log(e.Message, LogType.ERROR);
            }
        }
        
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            try
            {
                _listeners[i]?.OnEventRaised();
            }
            catch (Exception e)
            {
                DebugUtil.Log(e.Message, LogType.ERROR);
            }
        }
        
        _actions.ForEach(x => x?.Invoke());
    }

    public void AddListener(IGameEventListener pListener)
    {
        if (!_listeners.Contains(pListener))
        {
            _listeners.Add(pListener);
        }
    }

    public void AddListener(Action pAction)
    {
        if (!_actions.Contains(pAction)) _actions.Add(pAction);
    }

    public void RemoveListener(IGameEventListener pListener)
    {
        if (_listeners.Contains(pListener))
        {
            _listeners.Remove(pListener);
        }
    }

    public void RemoveListener(Action pAction)
    {
        if (_actions.Contains(pAction)) _actions.Remove(pAction);
    }
}