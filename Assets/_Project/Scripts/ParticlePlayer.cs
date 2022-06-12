using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private bool _attachToSelf = false;
    [SerializeField] private ParticleSystem _particlePrefab;

    public void PlayAt(Collision pCollision)
    {
        //Get the average of all contact points
        
        Vector3 totalPosition = Vector3.zero;
        Vector3 totalRotation = Vector3.zero;

        foreach (ContactPoint point in pCollision.contacts)
        {
            totalPosition += point.point;
            totalRotation += point.normal.normalized;
        }

        Vector3 averagePosition = totalPosition / pCollision.contactCount;
        Vector3 averageRotation = totalRotation / pCollision.contactCount;

        spawnParticleSystem(averagePosition, averageRotation.normalized);
    }

    public void PlayAt(GameObject pObject)
    {
        spawnParticleSystem(pObject.transform.position, Vector3.zero);
    }

    public void PlayAtSelf()
    {
        spawnParticleSystem(transform.position, Vector3.zero);
    }

    private ParticleSystem spawnParticleSystem(Vector3 pPosition, Vector3 pRotation)
    {
        Transform parent = _attachToSelf ? transform : null;
        Quaternion rotation = pRotation.magnitude == 0 ? Quaternion.identity : Quaternion.LookRotation(pRotation);
        
        ParticleSystem pSystem = Instantiate(_particlePrefab, pPosition, rotation, parent);

        return pSystem;
    }
}
