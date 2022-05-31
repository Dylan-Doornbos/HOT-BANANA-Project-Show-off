using System.Collections;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    public void SafeDelete(GameObject pObj)
    {
        StartCoroutine(delete(pObj));
    }

    private IEnumerator delete(GameObject pObj)
    {
        yield return null;
        
        Destroy(pObj);
    }

}