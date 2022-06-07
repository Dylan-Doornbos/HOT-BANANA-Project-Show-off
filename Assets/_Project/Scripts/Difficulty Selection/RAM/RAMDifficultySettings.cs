using UnityEngine;

[CreateAssetMenu(menuName = "Difficulties/RAM")]
public class RAMDifficultySettings : Difficulty
{
    [field: SerializeField] public string difficultyName { get; private set; } = "Unspecified";
    [field: SerializeField] public float conveyorSpeed { get; private set; } = 0.25f;
    [field: SerializeField] public float spawnIntervalInSeconds { get; private set; } = 3f;
}