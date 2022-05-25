using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Path _path;

    [Header("Properties")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _waypointWaitTime = 1;
    [SerializeField] private Ease _easing;
    [SerializeField] private bool _curvedPath;
    [SerializeField] private bool _rotateUpDown;
    [SerializeField] private bool _loop = false;

    private Vector3 _lastPosition;
    private List<Vector3> _waypoints;

    Tween _moveTween;

    private void Start()
    {
        _waypoints = getWaypoints();
        followPath(_waypoints.ToArray());
    }

    private void Update()
    {
        if (transform.position == _lastPosition) return;

        Vector3 forward = transform.position - _lastPosition;
        forward.y = _rotateUpDown ? forward.y : 0;
        transform.forward = forward;

        _lastPosition = transform.position;
    }

    private List<Vector3> getWaypoints()
    {
        int listSize = _path.waypoints.Length;

        List<Vector3> waypoints = new List<Vector3>();
        waypoints.Add(_path.waypoints[listSize - 2]);
        waypoints.Add(_path.waypoints[listSize - 1]);
        waypoints.AddRange(_path.waypoints.ToList());
        waypoints.Add(_path.waypoints[0]);
        waypoints.Add(_path.waypoints[1]);

        return waypoints;
    }

    private void followPath(Vector3[] pPath)
    {
        float loopDuration = _path.GetDistance() / _moveSpeed;

        _moveTween?.Kill();

        PathType pathType = _curvedPath ? PathType.CatmullRom : PathType.Linear;

        _moveTween = transform.DOPath(pPath, loopDuration, pathType, PathMode.Full3D, 10,
            new Color(0, 0, 0, 0))
            .SetEase(_easing).OnWaypointChange(onWaypointChanged);

        int index = _loop ? 2 : 3;
        _moveTween.GotoWaypoint(index, true);
    }

    private void onWaypointChanged(int pIndex)
    {
        if(pIndex == _path.waypoints.Length + 2)
        {
            if (!_loop) _waypoints.Reverse();

            followPath(_waypoints.ToArray());
        }
        else
        {
            StartCoroutine(waitAtWaypoint(_waypointWaitTime, pIndex));
        }
    }

    private IEnumerator waitAtWaypoint(float pSeconds, int pIndex)
    {
        _moveTween.Pause();

        yield return new WaitForSeconds(pSeconds);

        _moveTween.Play();

        yield return null;
    }
}