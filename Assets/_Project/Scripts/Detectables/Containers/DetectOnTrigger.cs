using UnityEngine;

[RequireComponent(typeof(IDetector))]
public class DetectOnTrigger : MonoBehaviour
{
    [SerializeField] private bool _detectOnTriggerEnter = false;
    [SerializeField] private bool _detectOnTriggerExit = false;

    private IDetector[] _detectors;

    private void Start()
    {
        _detectors = GetComponents<IDetector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_detectOnTriggerEnter) tryDetectObject(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_detectOnTriggerExit) tryDetectObject(other.gameObject);
    }

    private void tryDetectObject(GameObject pObject)
    {
        if (_detectors == null || _detectors.Length == 0) return;

        foreach (IDetector detector in _detectors)
        {
            detector.Detect(pObject);
        }
    }
}
