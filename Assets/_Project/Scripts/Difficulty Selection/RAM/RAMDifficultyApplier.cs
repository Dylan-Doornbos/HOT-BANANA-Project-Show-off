using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RAMDifficultyApplier : DifficultyApplier<RAMSelectedDifficulty, RAMDifficultySettings>
{
    [Header("References")] [SerializeField]
    private ObjectSpawner_Random _spawner;
    [SerializeField] private Countdown _respawnTimer;
    [SerializeField] private GameObject _conveyorBelt;
    [SerializeField] private Countdown _gameTimer;

    protected override void applyDifficulty()
    {
        List<GameObject> objectsToSpawn = new List<GameObject>();
        
        foreach (Detectable detectable in _settingsToApply.detectables)
        {
            objectsToSpawn.Add(detectable.gameObject);
        }
        
        _spawner.SetObjectsToSpawn(objectsToSpawn);
        _respawnTimer.SetDuration(_settingsToApply.spawnIntervalInSeconds);
        _conveyorBelt.GetComponentInChildren<ConveyorBelt>().SetSpeed(_settingsToApply.conveyorSpeed);
        _conveyorBelt.SetActive(_settingsToApply.enableConveyorBelt);
        _gameTimer.SetDuration(_settingsToApply.durationInSeconds);
    }
}