using UnityEngine;

[CreateAssetMenu(menuName = "Difficulties/Settings/RAM")]
public class RAMDifficultySettings : DifficultySettings
{
    [field: SerializeField] public string difficultyName { get; private set; } = "Unspecified";
    [field: SerializeField] public float conveyorSpeed { get; private set; } = 0.25f;
    [field: SerializeField] public float spawnIntervalInSeconds { get; private set; } = 3f;
    [field: SerializeField] public Detectable[] detectables { get; private set; } = null;
}