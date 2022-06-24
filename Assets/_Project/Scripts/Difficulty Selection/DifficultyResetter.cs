using UnityEngine;

public class DifficultyResetter : MonoBehaviour
{
    [SerializeField] private RAMSelectedDifficulty _RAMSettings;
    [SerializeField] private ROMSelectedDifficulty _ROMSettings;

    private void OnEnable()
    {
        if (_RAMSettings != null)
        {
            _RAMSettings.Reset();
        }

        if (_ROMSettings != null)
        {
            _ROMSettings.Reset();
        }
    }
}