using UnityEngine;
using UnityEngine.Events;

public class OnDestroyed : MonoBehaviour
{
    [SerializeField] public UnityEvent onDestroyed = new UnityEvent();

    private bool _isQuitting = false;

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void OnDestroy()
    {
        if(!_isQuitting)
        {
            onDestroyed?.Invoke();
        }
    }
}
