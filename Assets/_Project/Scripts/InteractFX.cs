using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractFX : MonoBehaviour
{
    public static event Action onInteracted;

    private Button _button;
    private XRSimpleInteractable _interactable;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(play);

        if (_interactable != null)
            _interactable.selectEntered.AddListener(play);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(play);

        if (_interactable != null)
            _interactable.selectEntered.RemoveListener(play);
    }

    private void play()
    {
        onInteracted?.Invoke();
    }

    private void play(SelectEnterEventArgs pArgs)
    {
        play();
    }
}