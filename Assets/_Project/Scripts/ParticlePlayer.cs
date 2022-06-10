using Unity.Mathematics;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] private bool _attachToSelf = false;
    [SerializeField] private ParticleSystem _particlePrefab;

    public void Play(Collision pCollision)
    {
        spawnParticleSystem(pCollision.GetContact(0).point, pCollision.relativeVelocity.normalized);
    }

    private ParticleSystem spawnParticleSystem(Vector3 pPosition, Vector3 pRotation)
    {
        Transform parent = _attachToSelf ? transform : null;

        ParticleSystem pSystem = Instantiate(_particlePrefab, pPosition, quaternion.Euler(pRotation), parent);

        return pSystem;
    }
}
