using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectSpawner : MonoBehaviour
{
    [Header("Optional")]
    [Tooltip("If left empty, the current game object will be used.")]
    [SerializeField] protected Transform _spawnPointOverride;
    [Space]
    [SerializeField] public UnityEvent<GameObject> onObjectSpawned;

    protected virtual void Awake()
    {
        if (_spawnPointOverride == null) _spawnPointOverride = gameObject.transform;
    }

    public void Spawn()
    {
        if(spawn(out GameObject objSpawned))
        {
            onObjectSpawned?.Invoke(objSpawned);
        }
    }

    protected abstract bool spawn(out GameObject objectSpawned);

    protected void spawnObject(GameObject obj)
    {
        if(obj == null)
        {
            DebugUtil.Log($"The object you're trying to spawn is not valid.\nSource object: '{gameObject.name}'.", LogType.ERROR);
        }
    }
}
