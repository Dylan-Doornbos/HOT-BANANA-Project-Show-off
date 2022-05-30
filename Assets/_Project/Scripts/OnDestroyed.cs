using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnDestroyed : MonoBehaviour
{
    [SerializeField] public UnityEvent onDestroyed = new UnityEvent();

    private bool _canDestroy = false;

    private void OnApplicationQuit()
    {
        _canDestroy = false;
    }

    public void Stop()
    {
        _canDestroy = false;
    }

    private void OnDestroy()
    {
        if(_canDestroy && gameObject.scene.isLoaded)
        {
            onDestroyed?.Invoke();
        }
    }
}
