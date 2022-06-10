using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Playables;

[Serializable]
public class SubtitleControlBehaviour : PlayableBehaviour
{
    [SerializeField] private LocalizedString line;

    private bool _hasPlayed = false;

    private SubtitleController _controller;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
        _hasPlayed = false;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (_hasPlayed) return;
        _hasPlayed = true;

        if (!(playerData is SubtitleController controller)) return;

        _controller = controller;
        
        var test = line.GetLocalizedString();
        _controller.SetLine(test);
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (_controller != null) _controller.Hide();
    }
}