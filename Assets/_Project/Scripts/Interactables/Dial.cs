using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(SingleAxisRotator))]
public class Dial : RotateInteractor<SingleAxisRotator>
{
    [SerializeField] private UnityEvent _onRotated;

    private Vector2 _startUpRotation;
    private Vector2 _startRightRotation;
    private float _startProgress;

    public void SetSteps(int pSteps)
    {
        _rotator.SetPrecision(_rotator.maxRotation / (float) pSteps);
    }

    protected override void startRotating()
    {
        base.startRotating();

        _startProgress = GetProgress();

        if (_interactor != null)
        {
            _startUpRotation = getControllerRotation(_interactor);
            _startRightRotation = new Vector2(_startUpRotation.y, -_startUpRotation.x);
        }
    }

    protected override void updateRotating()
    {
        if (_rotator == null || _interactor == null) return;

        Vector2 controllerRotation = getControllerRotation(_interactor);

        float angle = Vector2.Angle(controllerRotation, _startUpRotation);
        float dot = Vector2.Dot(controllerRotation, _startRightRotation);

        if (dot < 0)
        {
            angle = 360 - angle;
        }

        float progress = angleToProgress(angle) + _startProgress;

        //loop the progress back to a range between 0 and 1 when the provided rotator can make a full 360 degrees rotation.
        if (_rotator.maxRotation > 359.9f && _rotator.maxRotation < 360.1f)
        {
            progress %= 1;
        }

        SetProgress(progress);
    }

    private Vector2 getControllerRotation(XRRayInteractor pInteractor)
    {
        Vector2 controllerRotation = Vector2.zero;
        controllerRotation.x = -pInteractor.transform.right.y;
        controllerRotation.y = pInteractor.transform.up.y;

        return controllerRotation;
    }

    private float angleToProgress(float pAngle)
    {
        float angle = pAngle % 360;
        angle = Mathf.Clamp(angle, 0, _rotator.maxRotation);

        float progress = angle / _rotator.maxRotation;

        return progress;
    }

    /// <summary>
    /// Returns the progress of the dial as a value between 0 and 1 where 0 = 0% and 1 = 100%
    /// </summary>
    /// <returns></returns>
    public float GetProgress()
    {
        return _rotator.GetAngle() / _rotator.maxRotation;
    }

    /// <summary>
    /// Sets the progress of the dial.
    /// </summary>
    /// <param name="pProgress">The progress between 0 and 1 where 0 = 0% and 1 = 100%</param>
    public void SetProgress(float pProgress)
    {
        if (_rotator == null || _interactor == null) return;

        pProgress = Mathf.Clamp(pProgress, 0, 1);

        float angle = pProgress * _rotator.maxRotation;

        _rotator.SetRotation(angle);
    }
}