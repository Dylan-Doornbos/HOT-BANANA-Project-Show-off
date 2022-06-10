using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class DifficultySelector<T1, T2> : MonoBehaviour where T1 : SelectedDifficulty<T2> where T2 : DifficultySettings
{
    [field: SerializeField] public T1 _selectedDifficulty { get; private set; }
    [field: SerializeField] public T2 _difficultyToSelect { get; private set; }
    [SerializeField] private OnOffDisplay _onOffDisplay;
    
    private bool _isActive;
    private XRBaseInteractable _interactable;

    private void Awake()
    {
        _interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        _selectedDifficulty.onDifficultyChanged += changeActiveState;
        changeActiveState(_selectedDifficulty.difficulty);
        _interactable.selectEntered.AddListener(Select);
    }

    private void OnDisable()
    {
        _selectedDifficulty.onDifficultyChanged -= changeActiveState;
        _interactable.selectEntered.RemoveListener(Select);
    }

    public void Select(SelectEnterEventArgs pArgs)
    {
        _selectedDifficulty.SetDifficulty(_difficultyToSelect);
    }

    private void changeActiveState(DifficultySettings pDifficulty)
    {
        _isActive = pDifficulty == _difficultyToSelect;
        _onOffDisplay.SetState(_isActive);
    }
    
}