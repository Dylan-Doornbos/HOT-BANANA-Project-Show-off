using UnityEngine;

public class SingleAxisRotator : Rotator
{
    public Vector3 rotateAxis { get; private set; }
    public Vector3 forwardDirection { get; private set; }

    private void Awake()
    {
        rotateAxis = -transform.right;
        forwardDirection = transform.forward;
    }

    /// <summary>
    /// Gets the angle of the rotator relative to its starting rotation
    /// </summary>
    /// <returns></returns>
    public float GetAngle()
    {
        float angle = Vector3.Angle(transform.forward, forwardDirection);

        float dot = Vector3.Dot(forwardDirection, transform.up);

        if (dot < 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }

    /// <summary>
    /// Sets the rotation of the rotator base on an angle. (Relative to its starting rotation)
    /// </summary>
    /// <param name="pAngle">The angle to rotate at</param>
    public void SetRotation(float pAngle)
    {
        Vector3 lookDirection = Quaternion.AngleAxis(pAngle, -rotateAxis) * forwardDirection;
        SetRotation(lookDirection);
    }

    public override void SetRotation(Vector3 pLookDirection)
    {
        float dot = Vector3.Dot(pLookDirection, rotateAxis);
        pLookDirection -= dot * rotateAxis;
        Vector3 newUp = Quaternion.AngleAxis(-90, -rotateAxis) * pLookDirection;
        transform.rotation = Quaternion.LookRotation(pLookDirection, newUp);
    }
}
