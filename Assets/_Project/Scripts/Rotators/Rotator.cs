using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    /// <summary>
    /// Sets the rotation of the rotator.
    /// </summary>
    /// <param name="pTransformToPoint">The direction to look at.</param>
    public abstract void SetRotation(Vector3 pTransformToPoint);
}
