using UnityEngine;

public static class TransformHelper
{
    public static void DeleteChildren(Transform pTransform)
    {
        if(pTransform.childCount == 0) return;

        for (int i = pTransform.childCount; i >= 0; i--)
        {
            GameObject.Destroy(pTransform.GetChild(i).gameObject);
        }
    }
}
