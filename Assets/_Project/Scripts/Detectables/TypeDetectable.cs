using UnityEngine;
using UnityEngine.Events;

public class TypeDetectable : MonoBehaviour
{
    [field: SerializeField] public DetectionType detectionType { get; private set; }
    [field: SerializeField] public UnityEvent onDetected;

    private void Awake()
    {
        if (detectionType == null)
            DebugUtil.Log($"{detectionType.name} is not defined on {gameObject.name}", LogType.ERROR);
    }

    public void Detect()
    {
        onDetected?.Invoke();
    }
}