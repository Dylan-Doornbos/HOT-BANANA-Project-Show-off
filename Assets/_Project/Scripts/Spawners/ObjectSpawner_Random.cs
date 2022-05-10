using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_Random : ObjectSpawner
{
    [SerializeField] List<GameObject> _objectsToSpawn = new List<GameObject>();

    private string _noObjectsWarning => $"{nameof(_objectsToSpawn)} does not have any game objects to spawn.\nSource object '{gameObject.name}'";

    private void Awake()
    {
        if (_objectsToSpawn == null || _objectsToSpawn.Count == 0)
        {
            DebugUtil.Log(_noObjectsWarning, LogType.WARNING);
        }
        else
        {
            foreach(GameObject obj in _objectsToSpawn)
            {
                if (obj == null) DebugUtil.Log($"One of the objects marked for spawning is invalid.\nSource object '{gameObject.name}'.", LogType.ERROR);
            }
        }
    }

    public override void Spawn()
    {
        if (_objectsToSpawn == null || _objectsToSpawn.Count == 0)
        {
            DebugUtil.Log(string.Format(_noObjectsWarning, gameObject.name), LogType.WARNING);
            return;
        }

        int index = Random.Range(0, _objectsToSpawn.Count);
        GameObject objectToSpawn = _objectsToSpawn[index];

        Instantiate(objectToSpawn, _spawnPoint.position, Quaternion.identity);
    }
}
