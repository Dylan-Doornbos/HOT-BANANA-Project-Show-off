using UnityEngine;
using UnityEngine.Events;

public abstract class ObjectSpawner : MonoBehaviour
{
    [Header("Optional")]
    [Tooltip("Defines where the objects will spawn.\nIf left empty, the current game object will be used.")]
    [SerializeField] protected Transform _spawnPosition;
    [Tooltip("Defines the GameObject the objects will be spawned in.\nIf left empty, the current game object will be used.")]
    [SerializeField] protected Transform _spawnedObjParent;
    [Space]
    [SerializeField] public UnityEvent<GameObject> onObjectSpawned;

    protected virtual void Awake()
    {
        if (_spawnPosition == null) _spawnPosition = transform;
        if (_spawnedObjParent == null) _spawnedObjParent = transform;
    }

    public void Spawn()
    {
        if(tryGetObjectToSpawn(out GameObject objectToSpawn))
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, _spawnPosition.position, Quaternion.identity, _spawnedObjParent);
            onObjectSpawned?.Invoke(spawnedObject);
        }
    }

    protected abstract bool tryGetObjectToSpawn(out GameObject pObjectToSpawn);

    protected void spawnObject(GameObject obj)
    {
        if(obj == null)
        {
            DebugUtil.Log($"The object you're trying to spawn is not valid.\nSource object: '{gameObject.name}'.", LogType.ERROR);
        }
    }
}
