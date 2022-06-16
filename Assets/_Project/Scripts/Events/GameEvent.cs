using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Game Event", fileName = "New Event")]
public class GameEvent : ScriptableObject
{
    [NonSerialized] private List<IGameEventListener> _listeners = new List<IGameEventListener>();
    [SerializeField] private List<GameEvent> _chainedEvents;

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
    }

    public void AddListener(IGameEventListener pListener)
    {
        if (!_listeners.Contains(pListener))
        {
            _listeners.Add(pListener);
        }
    }

    public void RemoveListener(IGameEventListener pListener)
    {
        if (_listeners.Contains(pListener))
        {
            _listeners.Remove(pListener);
        }
    }
}