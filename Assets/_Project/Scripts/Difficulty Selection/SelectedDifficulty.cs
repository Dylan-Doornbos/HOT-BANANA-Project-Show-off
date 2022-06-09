using System;
using UnityEngine;

public abstract class SelectedDifficulty<T> : ScriptableObject where T : DifficultySettings
{
    [field: SerializeField] public T difficulty { get; private set; }
    public event Action<T> onDifficultyChanged;

    public void SetDifficulty(T pDifficulty)
    {
        if(difficulty == pDifficulty) return;

        difficulty = pDifficulty;
        onDifficultyChanged?.Invoke(difficulty);
    }
}
