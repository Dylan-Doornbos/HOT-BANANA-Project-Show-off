using System;
using UnityEngine;
using UnityEngine.Playables;

public class NarrationController : MonoBehaviour
{
    public static NarrationController instance;
    
    private PlayableDirector _activeDirector;

    private void Awake()
    {
        instance = this;
    }

    public void Play(PlayableDirector pDirector)
    {
        if (_activeDirector != null) _activeDirector.Stop();

        _activeDirector = pDirector;
        pDirector.Play();
    }

    public void Stop()
    {
        if (_activeDirector == null) return;
        
        _activeDirector.Stop();
        _activeDirector = null;
    }
}