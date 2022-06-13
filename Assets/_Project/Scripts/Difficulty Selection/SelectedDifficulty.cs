using System;
using UnityEngine;

public abstract class SelectedDifficulty<T> : ScriptableObject where T : DifficultySettings
{
    [SerializeField] private T _defaultDifficulty;
    [NonSerialized] private T _difficulty = null;

    public T difficulty
    {
        get
        {
            if (_difficulty == null) SetDifficulty(_defaultDifficulty);
            return _difficulty;
        }
    }
    
    public event Action<T> onDifficultyChanged;

    public void SetDifficulty(T pDifficulty)
    {
        if(_difficulty == pDifficulty) return;

        _difficulty = pDifficulty;
        onDifficultyChanged?.Invoke(pDifficulty);
    }
}
