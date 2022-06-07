using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private Difficulty _activeDifficulty;
    [SerializeField] private Difficulty _difficultyToSelect;

    private void OnValidate()
    {
        if(_activeDifficulty == null || _difficultyToSelect == null) return;

        if (_activeDifficulty.GetType() != _difficultyToSelect.GetType())
        {
            DebugUtil.Log($"'{nameof(_difficultyToSelect)}' is not the same type ({_difficultyToSelect.GetType()}) of difficulty as '{nameof(_activeDifficulty)}' ({_activeDifficulty.GetType()}). Source: '{gameObject.name}'.", LogType.ERROR);
        }
    }

    public void Select()
    {
        _activeDifficulty = _difficultyToSelect;
    }
}
