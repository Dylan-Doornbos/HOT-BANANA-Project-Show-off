using UnityEngine;
using UnityEngine.Events;

public class Detectable : MonoBehaviour
{
    [field: SerializeField] public DetectionType type { get; private set; }
    [field: SerializeField] public bool canDetectMoreThanOnce = false;
    [field: SerializeField] public UnityEvent onDetected;

    private bool _hasBeenDetected = false;

    public bool isDetectable => canDetectMoreThanOnce || !_hasBeenDetected;
    
    public void Detect()
    {
        _hasBeenDetected = true;
        onDetected?.Invoke();
    }
}
