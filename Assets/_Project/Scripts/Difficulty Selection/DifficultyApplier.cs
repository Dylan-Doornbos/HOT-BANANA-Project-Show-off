using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyApplier<T1, T2> : MonoBehaviour
{
    [SerializeField] private T1 _selectedDifficulty;
    [SerializeField] private T2 _defaultDifficulty;
}
