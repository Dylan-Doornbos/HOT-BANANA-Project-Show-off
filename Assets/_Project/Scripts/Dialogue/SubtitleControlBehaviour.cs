using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class SubtitleControlBehaviour : PlayableBehaviour
{
    [SerializeField] private int _lineIndex;
    [SerializeField] private SubtitleLines _lines;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (SubtitleController.instance == null) return;

        SubtitleController.instance.SetLine(_lines.GetLine(_lineIndex));
        
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (SubtitleController.instance == null) return;

        SubtitleController.instance.Hide();
    }
}