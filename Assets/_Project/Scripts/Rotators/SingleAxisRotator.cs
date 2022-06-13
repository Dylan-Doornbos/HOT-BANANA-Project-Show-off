using System;
using UnityEngine;
using UnityEngine.Events;

public class SingleAxisRotator : Rotator
{
    [SerializeField] private UnityEvent _onRotated;
    
    public Vector3 rotateAxis { get; private set; }
    public Vector3 defaultForwardDirection { get; private set; }
    public Vector3 defaultLeftDirection { get; private set; }
    public float maxRotation { get; private set; } = 360;
    public float precisionInDegrees { get; private set; } = 1;

    private void Awake()
    {
        rotateAxis = -transform.right.normalized;
        defaultForwardDirection = transform.forward.normalized;
        defaultLeftDirection = transform.up.normalized;
    }

    /// <summary>
    /// Gets the angle of the rotator relative to its starting rotation
    /// </summary>
    /// <returns></returns>
    public float GetAngle()
    {
        return getRelativeAngle(transform.forward);
    }

    /// <summary>
    /// Sets the precision of the rotator in degrees so it can only be rotated to angles that are divisible by this precision number.
    /// </summary>
    /// <param name="pDegrees"></param>
    public void SetPrecision(float pDegrees)
    {
        precisionInDegrees = pDegrees;
        SetRotation(GetAngle());
    }

    /// <summary>
    /// Sets the rotation of the rotator base on an angle. (Relative to its starting rotation)
    /// </summary>
    /// <param name="pAngle">The angle to rotate at</param>
    public void SetRotation(float pAngle)
    {
        //Snap the angle to fit the precision
        float angle = Mathf.RoundToInt(pAngle / precisionInDegrees) * precisionInDegrees;

        if (Math.Abs(GetAngle() - angle) > 0.1f && Math.Abs(GetAngle() - angle) < 359.5f)
        {
            _onRotated?.Invoke();
        }

        Vector3 newForwardDirection = Quaternion.AngleAxis(angle, -rotateAxis) * defaultForwardDirection;
        Vector3 newLeftDirection = Quaternion.AngleAxis(-90, -rotateAxis) * newForwardDirection;

        transform.rotation = Quaternion.LookRotation(newForwardDirection, newLeftDirection);
    }

    public override void SetRotation(Vector3 pLookDirection)
    {
        //Modifies the look direction to make sure it's on the same plane as the rotate axis
        float dot = Vector3.Dot(pLookDirection.normalized, rotateAxis);
        pLookDirection -= dot * rotateAxis;

        float angle = getRelativeAngle(pLookDirection);

        SetRotation(angle);
    }

    /// <summary>
    /// Gets the relative angle between the given vector and the default forward vector.
    /// </summary>
    /// <param name="pLookDirection"></param>
    /// <returns></returns>
    private float getRelativeAngle(Vector3 pLookDirection)
    {
        //Returns an angle between 0 and 180 regardless of the whether the lookDirection points to the left or right
        float angle = Vector3.Angle(pLookDirection, defaultForwardDirection);

        //Converts the angle to a value between 180 and 360 if the lookDirection points to the left
        float dot = Vector3.Dot(pLookDirection, defaultLeftDirection);
        if(dot > 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }
}
