using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(SingleAxisRotator))]
public class Dial : RotateInteractor<SingleAxisRotator>
{
    [SerializeField] private UnityEvent _onRotated;
    
    public void SetSteps(int pSteps)
    {
        _rotator.SetPrecision(_rotator.maxRotation / (float) pSteps);
    }

    protected override void updateRotating()
    {
        base.updateRotating();

        float progress = angleToProgress(_rotator.GetAngle());

        SetProgress(progress);
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