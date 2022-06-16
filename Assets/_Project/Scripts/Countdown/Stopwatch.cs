using UnityEngine;

public class Stopwatch : Timer
{

    protected override void tick()
    {
        time += Time.deltaTime;
    }

    public override void Reset()
    {
        time = 0;
    }
}
