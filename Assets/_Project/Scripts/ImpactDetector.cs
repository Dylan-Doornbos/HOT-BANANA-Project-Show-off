using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImpactDetector : MonoBehaviour
{
    [SerializeField] private float _speedThreshold = 1;
    [SerializeField] private UnityEvent<Collision> _onImpact;
    private List<Vector3> impactnormals = new List<Vector3>();

    private void OnDrawGizmos()
    {
        foreach (Vector3 vector3 in impactnormals)
        {
            Gizmos.DrawLine(Vector3.zero, vector3.normalized);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float impactSpeed = getImpactSpeed(collision);
        
        if (impactSpeed >= _speedThreshold)
        {
            impactnormals.Add(collision.GetContact(0).normal);
            _onImpact?.Invoke(collision);
        }
    }

    private float getImpactSpeed(Collision pCollision)
    {
        Vector3 normal = pCollision.GetContact(0).normal.normalized;
        float speed = Vector3.Dot(normal, pCollision.relativeVelocity);
        
        return speed;
    }
}
