using System;
using UnityEngine;

public class ROMSequenceDisplay : MonoBehaviour
{
    [SerializeField] private ROMSequence _sequence;
    [SerializeField] private ROMDisplay[] _displays;

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

    private void updateDisplay(ROMType pType)
    {
        for (int i = 0; i < _sequence.queueSize && i < _displays.Length; i++)
        {
            if (_displays[i] == null) return;
            
            _displays[i].SetType(_sequence.types[i]);
        }
    }
}