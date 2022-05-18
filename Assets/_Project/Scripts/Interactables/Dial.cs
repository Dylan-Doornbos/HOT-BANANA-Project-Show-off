using UnityEngine;

[RequireComponent(typeof(SingleAxisRotator))]
public class Dial : RotateInteractor<SingleAxisRotator>
{
    public void SetSteps(int pSteps)
    {
        _rotator.SetPrecision(_rotator.maxRotation / (float)pSteps);
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
        if (_rotator == null) return;

        pProgress = Mathf.Clamp(pProgress, 0, 1);

        float angle = pProgress * _rotator.maxRotation;

        _rotator.SetRotation(angle);
    }
}
