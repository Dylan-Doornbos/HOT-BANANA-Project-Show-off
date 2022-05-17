using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    /// <summary>
    /// Sets the rotation of the rotator.
    /// </summary>
    /// <param name="pLookDirection">The direction to look at.</param>
    public abstract void SetRotation(Vector3 pLookDirection);
}
