using UnityEngine;

[RequireComponent(typeof(SingleAxisRotator))]
public class Dial : RotateInteractor<SingleAxisRotator>
{
    /// <summary>
    /// Returns the progress of the dial as a value between 0 and 1 where 0 = 0% and 1 = 100%
    /// </summary>
    /// <returns></returns>
    public float GetProgress()
    {
        return _rotator.GetAngle() / 360f;
    }

    /// <summary>
    /// Sets the progress of the dial.
    /// </summary>
    /// <param name="pProgress">The progress between 0 and 1 where 0 = 0% and 1 = 100%</param>
    public void SetProgress(float pProgress)
    {
        if (_rotator == null) return;

        float angle = pProgress * 360;

        _rotator.SetRotation(angle);
    }
}
