using System;
using UnityEngine;

public abstract class DifficultyApplier<T1, T2> : MonoBehaviour
    where T1 : SelectedDifficulty<T2>
    where T2 : DifficultySettings
{
    [Header("Difficulties")]
    [SerializeField] private T1 _selectedDifficulty;
    [SerializeField] private T2 _defaultDifficulty;

    protected T2 _settingsToApply;

    protected virtual void Awake()
    {
        if (_selectedDifficulty == null || _defaultDifficulty == null)
        {
            DebugUtil.Log($"Missing references for '{GetType()}' on '{gameObject.name}'.", LogType.ERROR);
        }
    }

    private void OnEnable()
    {
        getSettingsToApply();
        applyDifficulty();
    }

    private void getSettingsToApply()
    {
        if (_selectedDifficulty == null || _selectedDifficulty.difficulty == null)
        {
            if (_defaultDifficulty == null)
            {
                DebugUtil.Log($"No valid difficulty settings could be found for '{GetType()}' on '{gameObject.name}'", LogType.WARNING);
            }

            _settingsToApply = _defaultDifficulty;
        }
        else
        {
            _settingsToApply = _selectedDifficulty.difficulty;
        }
    }

    protected abstract void applyDifficulty();
}
