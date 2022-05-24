using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private float _moveSpeed;

    private TweenerCore<Vector3, DG.Tweening.Plugins.Core.PathCore.Path, PathOptions> tweener;

    private Vector3 _lastPosition;

    private void Start()
    {
        transform.position = _path.waypoints[0];
        run();
    }

    private void Update()
    {
        if (transform.position == _lastPosition) return;
        
        transform.forward = transform.position - _lastPosition;
        
        _lastPosition = transform.position;
    }

    private void run()
    {
        float loopDuration = _path.GetDistance() / _moveSpeed;

        List<Vector3> waypoints = _path.waypoints.ToList();
        waypoints.Add(waypoints[0]);
        tweener?.Kill();
        tweener = transform.DOPath(waypoints.ToArray(), loopDuration, PathType.CatmullRom, PathMode.Full3D, 10,
            Color.white);
        tweener.SetLoops(-1, LoopType.Restart);
        tweener.SetEase(Ease.Linear);
    }
}