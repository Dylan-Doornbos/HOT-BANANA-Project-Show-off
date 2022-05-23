using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    [NonSerialized] List<IGameEventListener> _listeners = new List<IGameEventListener>();

    public void Raise()
    {
        for(int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void AddListener(IGameEventListener pListener)
    {
        if(!_listeners.Contains(pListener))
        {
            _listeners.Add(pListener);
        }
    }

    public void RemoveListener(IGameEventListener pListener)
    {
        if(_listeners.Contains(pListener))
        {
            _listeners.Remove(pListener);
        }
    }
}
