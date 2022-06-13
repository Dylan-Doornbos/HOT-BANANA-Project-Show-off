using UnityEngine;
using UnityEngine.Events;

public class InteractFXListener : MonoBehaviour
{
    [SerializeField] private UnityEvent _onInteracted;

    private void OnEnable()
    {
        InteractFX.onInteracted += invoke;
    }

    private void OnDisable()
    {
        InteractFX.onInteracted -= invoke;
    }

    private void invoke()
    {
        _onInteracted?.Invoke();
    }
}
