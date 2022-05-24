using System;
using DG.Tweening;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public Vector3[] waypoints;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i], waypoints[i + 1]);
        }
        
        Gizmos.DrawLine(waypoints[waypoints.Length - 1], waypoints[0]);
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