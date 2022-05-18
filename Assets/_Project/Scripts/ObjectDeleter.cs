using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    private List<GameObject> _objectsToDelete = new List<GameObject>();

    public void SafeDelete(GameObject obj)
    {
        _objectsToDelete?.Add(obj);
    }

    private void LateUpdate()
    {
        if (_objectsToDelete == null || _objectsToDelete.Count == 0) return;

        foreach(GameObject obj in _objectsToDelete)
        {
            if (obj == null) continue;

            Destroy(obj);
        }

        _objectsToDelete.Clear();
    }
}
