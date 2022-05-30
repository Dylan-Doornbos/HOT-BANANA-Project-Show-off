using UnityEngine;
using UnityEngine.Timeline;

[TrackColor(1, 1, 0.5f)]
[TrackBindingType(typeof(SubtitleController))]
[TrackClipType(typeof(SubtitleControlClip))]
public class SubtitleControlTrack : TrackAsset
{
    [SerializeField] private SubtitleLines _lines;
}