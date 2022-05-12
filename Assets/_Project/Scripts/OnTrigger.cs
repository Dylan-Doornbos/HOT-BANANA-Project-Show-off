using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class OnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> _onTriggerEnter;
    [SerializeField] private UnityEvent<GameObject> _onTriggerStay;
    [SerializeField] private UnityEvent<GameObject> _onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter?.Invoke(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        _onTriggerStay?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _onTriggerExit?.Invoke(other.gameObject);
    }
}
