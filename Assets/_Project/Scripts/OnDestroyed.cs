using UnityEngine;
using UnityEngine.Events;

public class OnDestroyed : MonoBehaviour
{
    [SerializeField] public UnityEvent onDestroyed = new UnityEvent();

    private void OnDestroy()
    {
        onDestroyed?.Invoke();
    }
}
