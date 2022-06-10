using System;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : Movement
{
    [SerializeField] NavMeshAgent _navAgent;
    private bool _isMoving = false;

    public override float moveSpeed => _navAgent.velocity.magnitude;

    private void Update()
    {
        if (_isMoving)
        {
            handleDestinationCheck();
        }
    }

    private void handleDestinationCheck()
    {
        if (_navAgent.remainingDistance > 0.001f && _navAgent.hasPath) return;

        _isMoving = false;
        onDestinationReached?.Invoke();
    }

    protected override void moveToPosition(Vector3 pPosition)
    {
        if (!_navAgent.isOnNavMesh) return;
        if (!tryGetNearestNavMeshPoint(pPosition, out Vector3 point)) return;

        NavMeshPath path = new NavMeshPath();
        _navAgent.CalculatePath(point, path);

        if (path.status == NavMeshPathStatus.PathInvalid) return;

        _isMoving = true;
        _navAgent.path = path;
    }

    public override void SetPosition(Vector3 pPosition)
    {
        if (tryGetNearestNavMeshPoint(pPosition, out Vector3 point))
        {
            transform.position = point;
        }
    }

    private bool tryGetNearestNavMeshPoint(Vector3 pSource, out Vector3 pResult)
    {
        pResult = Vector3.zero;

        if (NavMesh.SamplePosition(pSource, out NavMeshHit hit, Mathf.Infinity, -1))
        {
            pResult = hit.position;
            return true;
        }

        return false;
    }
}