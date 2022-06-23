using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class SubtitleControlBehaviour : PlayableBehaviour
{
    [SerializeField] private string line;

    private bool _hasPlayed = false;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
        _hasPlayed = false;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (_hasPlayed) return;
        _hasPlayed = true;
        
        SubtitleController.instance.SetLine(line);
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        SubtitleController.instance.Stop();
    }
}