using UnityEngine;
using UnityEngine.Events;

public class TypeDetector : MonoBehaviour, IDetector
{
    [SerializeField] private DetectionType _typeToDetect;
    [Tooltip("False = Types not specified in 'Detection Type' won't trigger any Unity Events.")]
    [SerializeField] private bool _detectIncorrectTypes = false;
    [Space]
    [Tooltip("Called when an object with any type is detected, Correct or Incorrect.")]
    [SerializeField] private UnityEvent<GameObject> _onAnyTypeDetected;
    [SerializeField] private UnityEvent<GameObject> _onCorrectTypeDetected;
    [SerializeField] private UnityEvent<GameObject> _onIncorrectTypeDetected;
    [SerializeField] private UnityEvent<DetectionType> _onTypeChanged;

    //TODO: Error Handling
    //TODO: Implement onTrigger detection

    public void Detect(TypeDetectable pDetectable)
    {
        if (pDetectable == null || pDetectable.detectionType == null) return;

        if (_typeToDetect == pDetectable.detectionType)
        {
            _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
            _onCorrectTypeDetected?.Invoke(pDetectable.gameObject);
        }
        else if (_detectIncorrectTypes)
        {
            _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
            _onIncorrectTypeDetected?.Invoke(pDetectable.gameObject);
        }
    }

    public void Detect(GameObject pObject)
    {
        TypeDetectable detectable = pObject.GetComponent<TypeDetectable>();

        if (detectable == null) return;

        Detect(detectable);
    }

    public void SetDetectionType(DetectionType pDetectionType)
    {
        if (pDetectionType == null)
        {
            DebugUtil.Log($"Specified detection type is invalid in '{nameof(SetDetectionType)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return;
        }

        _typeToDetect = pDetectionType;
        _onTypeChanged?.Invoke(pDetectionType);
    }
    private void OnTriggerEnter(Collider other)
    {
        Detect(other.gameObject);
    }
}