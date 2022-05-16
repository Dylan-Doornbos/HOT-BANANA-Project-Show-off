using UnityEngine;

public class Dial : RotateInteractor
{
    private Vector3 upDirection;
    private Vector3 rightDirection;

    protected override void Awake()
    {
        base.Awake();
        upDirection = transform.up;
        rightDirection = transform.forward;
    }

    private float getAngle()
    {
        float angle = Vector3.Angle(transform.up, upDirection);

        float dot = Vector3.Dot(rightDirection, transform.up);

        if (dot < 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }

    public float GetProgress()
    {
        return getAngle() / 360f;
    }
}
