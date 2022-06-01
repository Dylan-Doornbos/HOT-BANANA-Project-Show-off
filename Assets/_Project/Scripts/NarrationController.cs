using UnityEngine;
using UnityEngine.Playables;

public class NarrationController : MonoBehaviour
{
    private PlayableDirector _activeDirector;

    public void Play(PlayableDirector pDirector)
    {
        if (_activeDirector != null) _activeDirector.Stop();

        pDirector.Play();
    }
}