using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SubtitleControlClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField] private SubtitleControlBehaviour _template = new SubtitleControlBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<SubtitleControlBehaviour>.Create(graph, _template);
    }
}
