using System;
using UnityEngine;

public class CullPasser : MonoBehaviour
{
    public event Action onVisible;
    public event Action onInvisible;

    private void OnBecameVisible()
    {
        onVisible?.Invoke();
    }

    private void OnBecameInvisible()
    {
        onInvisible?.Invoke();
    }
}
