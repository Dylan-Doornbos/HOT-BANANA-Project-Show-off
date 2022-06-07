using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float _strength;
    
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
            
            _rigidbodiesInRange[i].AddForce(transform.forward * _strength, ForceMode.Force);
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
}
