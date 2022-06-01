using UnityEngine;
using UnityEngine.Events;

public abstract class TypeDetector<T> : MonoBehaviour, IDetector where T : DetectionType
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

    public void Detect(GenericDetectable<T> pDetectable)
    {
        if (pDetectable == null || pDetectable.detectionType == null || !pDetectable.isDetectable) return;

        if (_typeToDetect == pDetectable.detectionType)
        {
            detectCorrectly(pDetectable);
        }
        else if (_detectIncorrectTypes)
        {
            detectIncorrectly(pDetectable);
        }
    }

    protected virtual void detectCorrectly(GenericDetectable<T> pDetectable)
    {
        _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
        _onCorrectTypeDetected?.Invoke(pDetectable.gameObject);
        pDetectable.Detect();
    }

    protected virtual void detectIncorrectly(GenericDetectable<T> pDetectable)
    {
        _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
        _onIncorrectTypeDetected?.Invoke(pDetectable.gameObject);
        pDetectable.Detect();
    }

    public void Detect(GameObject pObject)
    {
        if (!pObject.TryGetComponent(out GenericDetectable<T> detectable)) return;

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