using UnityEngine;

public class RAMDifficultyApplier : DifficultyApplier<RAMSelectedDifficulty, RAMDifficultySettings>
{
    [Header("References")]
    [SerializeField] private Countdown _respawnTimer;
    [SerializeField] private ConveyorBelt _conveyorBelt;
    
    protected override void applyDifficulty()
    {
        _respawnTimer.SetDuration(_settingsToApply.spawnIntervalInSeconds);
        _conveyorBelt.SetSpeed(_settingsToApply.conveyorSpeed);
    }
}