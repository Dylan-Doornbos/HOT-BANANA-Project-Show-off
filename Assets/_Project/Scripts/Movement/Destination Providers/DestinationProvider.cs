using UnityEngine;

[RequireComponent(typeof(Movement))]
public abstract class DestinationProvider : MonoBehaviour
{
    protected Movement _movement;

    protected virtual void Awake()
    {
        _movement = GetComponent<Movement>();
        if (_movement == null) DebugUtil.Log($"No '{typeof(Movement)}' component found on '{gameObject.name}'.", LogType.WARNING);
    }

    private void OnEnable()
    {
        if (_movement == null) return;

        _movement.onDestinationReached.AddListener(provideDestination);
    }

    private void OnDisable()
    {
        if (_movement == null) return;

        _movement.onDestinationReached.RemoveListener(provideDestination);
    }

    protected abstract void provideDestination();
}
