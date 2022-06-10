using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider))]
public class ConveyorBelt : MonoBehaviour
{
    [FormerlySerializedAs("_strength")] [SerializeField] private float _speed;
    
    private List<Rigidbody> _rigidbodiesInRange = new List<Rigidbody>();

    private void Awake()
    {
        if (TryGetComponent(out BoxCollider collider))
        {
            collider.isTrigger = true;
        }
    }

    private void Update()
    {
        for(int i = _rigidbodiesInRange.Count - 1; i >= 0; i--)
        {
            if (_rigidbodiesInRange[i] == null)
            {
                _rigidbodiesInRange.RemoveAt(i);
                continue;
            }
            
            _rigidbodiesInRange[i].AddForce(transform.forward * _speed, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb))
        {
            _rigidbodiesInRange.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rb))
        {
            _rigidbodiesInRange.Remove(rb);
        }
    }

    public void SetSpeed(float pSpeed)
    {
        _speed = pSpeed;
    }
}
