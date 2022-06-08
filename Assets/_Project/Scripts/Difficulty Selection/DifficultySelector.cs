using UnityEngine;

public abstract class DifficultySelector<T1, T2> : MonoBehaviour where T1 : SelectedDifficulty<T2> where T2 : DifficultySettings
{
    [SerializeField] private T1 _selectedDifficulty;
    [SerializeField] private T2 _difficultyToSelect;

    private void OnValidate()
    {
        if(_selectedDifficulty == null || _difficultyToSelect == null) return;

        if (_selectedDifficulty.GetType() != _difficultyToSelect.GetType())
        {
            DebugUtil.Log($"'{nameof(_difficultyToSelect)}' is not the same type ({_difficultyToSelect.GetType()}) of difficulty as '{nameof(_selectedDifficulty)}' ({_selectedDifficulty.GetType()}). Source: '{gameObject.name}'.", LogType.ERROR);
        }
    }

    public void Select()
    {
        _selectedDifficulty.difficulty = _difficultyToSelect;
    }
}