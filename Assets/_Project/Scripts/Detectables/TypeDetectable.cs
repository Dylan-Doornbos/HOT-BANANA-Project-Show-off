using UnityEngine;

public class TypeDetectable : MonoBehaviour
{
    [field: SerializeField] public DetectionType detectionType { get; private set; }

    private void Awake()
    {
        if (detectionType == null) DebugUtil.Log($"{detectionType.name} is not defined on {gameObject.name}", LogType.ERROR);
    }
}