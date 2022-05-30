using System.Collections;
using UnityEngine;

public class PathDestinationProvider : DestinationProvider
{
    [Header("References")]
    [SerializeField] private Path _path;
    [Header("Properties")]
    [SerializeField] private bool _loop;
    [SerializeField] private float _waitTimeAtWaypoint;

    private int _currentIndex = 0;
    private int _indexIncrementDirection = 1;

    private void Start()
    {
        _movement.SetPosition(_path.waypoints[0]);
        provideDestination();
    }

    protected override void provideDestination()
    {
        StartCoroutine(moveAfterWait());
    }

    private IEnumerator moveAfterWait()
    {
        yield return new WaitForSeconds(_waitTimeAtWaypoint);
        
        setNextWaypoint();
        _movement.MoveToPosition(_path.waypoints[_currentIndex]);
    }

    private void setNextWaypoint()
    {
        _currentIndex += _indexIncrementDirection;

        if (_currentIndex < 0 || _currentIndex >= _path.waypoints.Length)
        {
            //Loop or reverse
            if (_loop)
            {
                _currentIndex = _currentIndex < 0 ? _path.waypoints.Length - 1 : 0;
            }
            else
            {
                _indexIncrementDirection = -_indexIncrementDirection;
                _currentIndex += _indexIncrementDirection * 2;
            }
        }
    }
}
