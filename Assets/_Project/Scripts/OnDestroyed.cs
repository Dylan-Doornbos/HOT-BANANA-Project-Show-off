using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnDestroyed : MonoBehaviour
{
    [SerializeField] public UnityEvent onDestroyed = new UnityEvent();

    private bool _isQuitting = false;

    private void Awake()
    {
        SceneManager.activeSceneChanged += onSceneChanged;
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void onSceneChanged(Scene oldScene, Scene newScene)
    {
        _isQuitting = true;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= onSceneChanged;
        if(!_isQuitting)
        {
            onDestroyed?.Invoke();
        }
    }
}
