using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Difficulties/Settings/ROM")]
public class ROMDifficultySettings : DifficultySettings
{
    [field: SerializeField] public BeamSettings horizontalBeam { get; private set; }
    [field: SerializeField] public BeamSettings verticalBeam { get; private set; }
}

[Serializable]
public class BeamSettings
{
    [field: SerializeField] public bool enable { get; private set; }
    [field: SerializeField] public bool randomizeMovement { get; private set; }
    [field: SerializeField] public float speed { get; private set; }
}