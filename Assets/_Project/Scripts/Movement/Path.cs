using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public Vector3[] waypoints;

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