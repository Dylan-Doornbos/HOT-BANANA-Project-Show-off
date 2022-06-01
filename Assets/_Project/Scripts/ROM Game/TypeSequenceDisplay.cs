using System;
using UnityEngine;

public class TypeSequenceDisplay : MonoBehaviour
{
    [SerializeField] private TypeSequence _sequence;
    [SerializeField] private TypeDisplay[] _displays;

    private void Awake()
    {
        for (int i = _sequence.queueSize - 1; i < _displays.Length; i++)
        {
            _displays[i].gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _sequence.onActiveTypeChanged.AddListener(updateDisplay);
    }

    private void OnDisable()
    {
        _sequence.onActiveTypeChanged.AddListener(updateDisplay);
    }

    private void updateDisplay(DetectionType pType)
    {
        for (int i = 0; i < _sequence.queueSize && i < _displays.Length; i++)
        {
            if (_displays[i] == null) return;
            
            _displays[i].SetType(_sequence.types[i]);
        }
    }
}