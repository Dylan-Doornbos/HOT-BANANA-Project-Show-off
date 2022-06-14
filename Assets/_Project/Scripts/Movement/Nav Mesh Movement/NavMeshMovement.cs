using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private Vector2 _minMaxIdleTime;
    [SerializeField] private Transform _waypointContainer;
    [SerializeField] private UnityEvent _onDestinationReached;

    private List<Transform> _waypoints = new List<Transform>();


    private void Awake()
    {
        for (int i = _waypointContainer.childCount - 1; i >= 0; i--)
        {
            _waypoints.Add(_waypointContainer.GetChild(i));
        }
        
        moveToNextPoint();
    }

    private void moveToNextPoint()
    {
        if (tryGetDestination(out Vector3 destination))
        {
            NavMeshPath path = new NavMeshPath();
            _navAgent.CalculatePath(destination, path);

            if (path.status == NavMeshPathStatus.PathInvalid) return;

            _navAgent.path = path;
            StartCoroutine(waitTillDestination());
        }
    }

    private IEnumerator waitTillDestination()
    {
        yield return null;
        
        while (_navAgent.remainingDistance > 0.001f && _navAgent.hasPath)
        {
            yield return null;
        }

        _onDestinationReached?.Invoke();

        yield return new WaitForSeconds(Random.Range(_minMaxIdleTime.x, _minMaxIdleTime.y));
        
        moveToNextPoint();
    }

    private bool tryGetDestination(out Vector3 pDestination)
    {
        pDestination = Vector3.zero;
        
        Vector3 position = _waypoints[Random.Range(0, _waypoints.Count)].position;

        if (NavMesh.SamplePosition(position, out NavMeshHit hit, Mathf.Infinity, _navAgent.areaMask))
        {
            pDestination = hit.position;
            return true;
        }

        return false;
    }

    /*[SerializeField] NavMeshAgent _navAgent;
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
    }*/
}