using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _minMaxIdleTime;
    [SerializeField] private UnityEvent _onDestinationReached;
    [SerializeField] private UnityEvent _onStartedMoving;

    private NavMeshAgent _navAgent;
    private NavigationArea _navigationArea;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        setNavMeshLayer();
    }

    private void Start()
    {
        findNavigationArea();
        moveToNextPoint();
    }

    private void findNavigationArea()
    {
        List<NavigationArea> overlappingAreas = getOverlappingNavigationAreas();
        _navigationArea = highestpriorityArea(overlappingAreas);
    }

    private List<NavigationArea> getOverlappingNavigationAreas()
    {
        List<NavigationArea> overlappingAreas = new List<NavigationArea>();

        //Find all overlapping colliders
        Collider[] colliders = new Collider[10];
        int size = Physics.OverlapSphereNonAlloc(transform.position, 0.01f, colliders, -1, QueryTriggerInteraction.Collide);

        //Filter for colliders that are only part of a navigation area
        for (int i = 0; i < size; i++)
        {
            if (NavigationArea.colliderArea.TryGetValue(colliders[i], out NavigationArea area))
            {
                if (!overlappingAreas.Contains(area)) overlappingAreas.Add(area);
            }
        }

        return overlappingAreas;
    }

    private NavigationArea highestpriorityArea(List<NavigationArea> pArea)
    {
        if (pArea == null || pArea.Count == 0)
        {
            DebugUtil.Log($"no '{nameof(NavigationArea)}' provided for '{nameof(highestpriorityArea)}' on '{gameObject.name}'.", LogType.WARNING);
            return null;
        }

        NavigationArea highestArea = pArea[0];

        for (int i = 1; i < pArea.Count; i++)
        {
            if (pArea[i].priority > highestArea.priority)
                highestArea = pArea[i];
        }

        return highestArea;
    }

    private void setNavMeshLayer()
    {
        if (NavMesh.SamplePosition(_navAgent.transform.position, out NavMeshHit hit, Mathf.Infinity, -1))
        {
            _navAgent.areaMask = hit.mask;
        }
    }

    private void moveToNextPoint()
    {
        if(_navAgent == null) return;
        if (!tryGetDestination(out Vector3 destination)) return;

        if (!NavMesh.SamplePosition(destination, out NavMeshHit hit, Mathf.Infinity, _navAgent.areaMask))
        {
            DebugUtil.Log($"Could not sample position on Navmesh for '{gameObject.name}.'", LogType.WARNING);
            return;   
        }

        destination = hit.position;

        NavMeshPath path = new NavMeshPath();
        _navAgent.CalculatePath(destination, path);

        if (path.status == NavMeshPathStatus.PathInvalid) return;

        _onStartedMoving?.Invoke();
        _navAgent.path = path;
        StartCoroutine(waitTillDestination());
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
        if (_navigationArea == null)
        {
            DebugUtil.Log($"No '{nameof(NavigationArea)}' specified for '{nameof(tryGetDestination)}' on '{gameObject.name}'.", LogType.WARNING);
            return false;
        }

        pDestination = _navigationArea.GetRandomPosition();

        return true;
    }
}