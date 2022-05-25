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
    [SerializeField] private bool _rotateUpDown;

    private Vector3 _lastPosition;
    private List<Vector3> _waypoints;

    Tween _moveTween;

    private void Start()
    {
        _waypoints = getWaypoints();
        followPath();
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

    private void followPath()
    {
        float loopDuration = _path.GetDistance() / _moveSpeed;

        _moveTween?.Kill();

        _moveTween = transform.DOPath(_waypoints.ToArray(), loopDuration, PathType.CatmullRom, PathMode.Full3D, 10,
            new Color(0, 0, 0, 0))
            .SetEase(Ease.Linear).OnWaypointChange(onWaypointChanged);

        _moveTween.GotoWaypoint(2, true);
    }

    private void onWaypointChanged(int index)
    {
        if(index == _path.waypoints.Length + 2)
        {
            followPath();
        }
    }
}