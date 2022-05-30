using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    public void SafeDelete(GameObject pObj)
    {
        Destroy(pObj);
    }

    public void ForceDelete(GameObject pObj)
    {
        if (pObj.TryGetComponent(out OnDestroyed component))
        {
            component.Stop();
        }
        
        SafeDelete(pObj);
    }
}