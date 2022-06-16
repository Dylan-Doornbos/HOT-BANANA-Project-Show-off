using System.Collections.Generic;
using UnityEngine;

public class RAMDifficultyApplier : DifficultyApplier<RAMSelectedDifficulty, RAMDifficultySettings>
{
    [Header("References")] [SerializeField]
    private ObjectSpawner_Random _spawner;
    [SerializeField] private Countdown _respawnTimer;
    [SerializeField] private ConveyorBelt _conveyorBelt;

    protected override void applyDifficulty()
    {
        List<GameObject> objectsToSpawn = new List<GameObject>();
        
        foreach (Detectable detectable in _settingsToApply.detectables)
        {
            objectsToSpawn.Add(detectable.gameObject);
        }
        
        _spawner.SetObjectsToSpawn(objectsToSpawn);
        _respawnTimer.SetDuration(_settingsToApply.spawnIntervalInSeconds);
        _conveyorBelt.SetSpeed(_settingsToApply.conveyorSpeed);
    }
}