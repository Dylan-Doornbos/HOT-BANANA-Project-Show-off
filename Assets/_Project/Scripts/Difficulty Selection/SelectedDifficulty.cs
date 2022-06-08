using UnityEngine;

public abstract class SelectedDifficulty<T> : ScriptableObject where T : DifficultySettings
{
    [field: SerializeField] public T difficulty;
}
