using UnityEngine;
using UnityEngine.Events;

public class GenericDetectable<T> : Detectable where T : DetectionType
{
    [field: SerializeField] public T detectionType { get; private set; }

    protected virtual void Awake()
    {
        if (detectionType == null)
            DebugUtil.Log($"{detectionType.name} is not defined on {gameObject.name}", LogType.ERROR);
    }
}