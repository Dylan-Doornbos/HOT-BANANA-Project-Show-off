using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private ObjectSpawner _spawner;

    //TODO: Error handling

    private void Awake()
    {
        if (_spawner == null)
        {
            _spawner = GetComponent<ObjectSpawner>();

            if (_spawner == null)
            {
                DebugUtil.Log($"'{nameof(_spawner)}' was not specified and a '{nameof(ObjectSpawner)}' component could not be found. Source object: '{gameObject.name}'", LogType.ERROR);
            }
        }

        if (_spawner != null)
        {
            _spawner.onObjectSpawned.AddListener(markObjectForRespawning);
        }
    }

    /// <summary>
    /// Registers to the spawned object's "OnDestroyed" event so when the spawned object is destroyed, the spawner spawns a new object.
    /// </summary>
    /// <param name="spawnedObject"></param>
    private void markObjectForRespawning(GameObject spawnedObject)
    {
        if (spawnedObject == null) return;

        OnDestroyed onDestroyedComponent = spawnedObject.GetComponent<OnDestroyed>();

        if (onDestroyedComponent == null)
            onDestroyedComponent = spawnedObject.AddComponent<OnDestroyed>();

        onDestroyedComponent.onDestroyed.AddListener(_spawner.Spawn);
    }
}