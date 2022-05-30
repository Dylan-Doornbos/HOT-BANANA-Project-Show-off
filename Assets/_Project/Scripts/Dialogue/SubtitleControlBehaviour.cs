using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class SubtitleControlBehaviour : PlayableBehaviour
{
    [SerializeField] private int _lineIndex;
    [SerializeField] private SubtitleLines _lines;
    [SerializeField, HideInInspector] public SubtitleControlTrack track;

    private SubtitleController _controller;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        _controller = playerData as SubtitleController;

        if (_controller == null) return;
        
        _controller.SetLine(_lines.GetLine(_lineIndex));
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (_controller == null) return;

        _controller.Hide();
    }
}