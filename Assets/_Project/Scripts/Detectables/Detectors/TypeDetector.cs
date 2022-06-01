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
    [SerializeField] private UnityEvent<GameObject> _onFirstCorrectTypeDetected;
    [SerializeField] private UnityEvent<GameObject> _onIncorrectTypeDetected;
    [SerializeField] private UnityEvent<GameObject> _onFirstIncorrectTypeDetected;
    [SerializeField] private UnityEvent<DetectionType> _onTypeChanged;

    private bool _firstCorrectDetected;
    private bool _firstIncorrectDetected;

    public void Detect(DetectableType pDetectable)
    {
        if (pDetectable == null || pDetectable.type == null || !pDetectable.isDetectable) return;

        if (_typeToDetect == pDetectable.type)
        {
            detectCorrectly(pDetectable);
        }
        else if (_detectIncorrectTypes)
        {
            detectIncorrectly(pDetectable);
        }
    }

    protected virtual void detectCorrectly(DetectableType pDetectable)
    {
        if (!_firstCorrectDetected) _onFirstCorrectTypeDetected?.Invoke(pDetectable.gameObject);

        _firstCorrectDetected = true;
        _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
        _onCorrectTypeDetected?.Invoke(pDetectable.gameObject);
        pDetectable.Detect();
    }

    protected virtual void detectIncorrectly(DetectableType pDetectable)
    {
        if(!_firstIncorrectDetected) _onFirstIncorrectTypeDetected?.Invoke(pDetectable.gameObject);

        _firstIncorrectDetected = true;
        _onAnyTypeDetected?.Invoke(pDetectable.gameObject);
        _onIncorrectTypeDetected?.Invoke(pDetectable.gameObject);
        pDetectable.Detect();
    }

    public void Detect(GameObject pObject)
    {
        if (!pObject.TryGetComponent(out DetectableType detectable)) return;

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