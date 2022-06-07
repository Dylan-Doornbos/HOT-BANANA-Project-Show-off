using UnityEngine;

public class RAMDifficultyApplier : MonoBehaviour
{
    [Header("Difficulties")] 
    [SerializeField] private RAMSelectedDifficulty _selectedDifficulty;
    [SerializeField] private RAMDifficultySettings _defaultDifficulty;

    [Header("References")]
    [SerializeField] private Countdown _respawnTimer;
    [SerializeField] private ConveyorBelt _conveyorBelt;

    private void OnEnable()
    {
        applyDifficulty();
    }

    private void applyDifficulty()
    {
        RAMDifficultySettings settingsToApply;
        
        if (_selectedDifficulty == null || _selectedDifficulty.activeSettings == null)
        {
            if(_defaultDifficulty == null) return;

            settingsToApply = _defaultDifficulty;
        }
        else
        {
            settingsToApply = _selectedDifficulty.activeSettings;
        }
        
        _respawnTimer.SetDuration(settingsToApply.spawnIntervalInSeconds);
        _conveyorBelt.SetSpeed(settingsToApply.conveyorSpeed);
    }
}