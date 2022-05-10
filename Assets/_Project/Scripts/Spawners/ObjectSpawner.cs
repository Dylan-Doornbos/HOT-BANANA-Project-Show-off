using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour
{
    [SerializeField] protected Transform _spawnPoint;

    public abstract void Spawn();

    protected void spawnObject(GameObject obj)
    {
        if(obj == null)
        {
            DebugUtil.Log($"The object you're trying to spawn is not valid.\nSource object: '{gameObject.name}'.", LogType.ERROR);
        }
    }
}
