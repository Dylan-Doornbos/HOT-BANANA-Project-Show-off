using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] bool _isGrounded = false;
    [SerializeField] public Vector3[] waypoints;

    [SerializeField, HideInInspector] private Vector3[] _previousWaypoints;

    private void OnValidate()
    {
        if(waypoints.Length > _previousWaypoints.Length)
        {
            Vector3 position = waypoints[waypoints.Length - 1];
        }
        else
        {
            for(int i = 0; i < waypoints.Length; i++)
            {
                //If the current waypoint changed, make sure the Y component is grounded or 0
                if (waypoints[i] == _previousWaypoints[i]) continue;

                if(Physics.Raycast(waypoints[i], Vector3.down, out RaycastHit hit, Mathf.Infinity))
                {
                    waypoints[i].y = hit.point.y;
                }
                else
                {
                    waypoints[i].y = 0;
                }
            }
        }

        _previousWaypoints = waypoints;
    }

    private Vector3 groundVector(Vector3 pVec)
    {
        if(Physics.Raycast(pVec, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            pVec.y = hit.point.y;
        }
        else
        {
            pVec.y = 0;
        }

        return pVec;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }
    }

    public float GetDistance()
    {
        float distance = 0;
        
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            distance += (waypoints[i] - waypoints[i + 1]).magnitude;
        }

        return distance;
    }
}