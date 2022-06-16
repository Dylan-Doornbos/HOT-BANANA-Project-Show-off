using System.Collections.Generic;
using UnityEngine;

public class NavigationArea : MonoBehaviour
{
    [field: SerializeField] public AreaMaskEnum layer { get; private set; }

    public static Dictionary<Collider, NavigationArea> colliderArea = new Dictionary<Collider, NavigationArea>();

    private Collider[] _colliders;

    private void Awake()
    {
        _colliders = GetComponentsInChildren<Collider>();

        foreach (Collider area in _colliders)
        {
            area.isTrigger = true;
            colliderArea.Add(area, this);
        }
    }

    public Vector3 GetRandomPosition()
    {
        Collider area = getRandomCollider();
        Bounds bounds = area.bounds;

        Vector3 rndPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        return rndPosition;
    }

    private Collider getRandomCollider()
    {
        Dictionary<Collider, float> areaWeight = new Dictionary<Collider, float>();
        float totalWeight = 0;

        //Store the size of each Collider to keep track of their weight
        foreach (Collider area in _colliders)
        {
            Bounds bounds = area.bounds;
            float weight = bounds.size.x + bounds.size.z;

            areaWeight.Add(area, weight);
            totalWeight += weight;
        }

        float rndWeight = Random.Range(0, totalWeight);

        //Find a collider based on the random weight
        foreach (Collider key in areaWeight.Keys)
        {
            if (areaWeight[key] <= totalWeight)
            {
                return key;
            }

            rndWeight -= areaWeight[key];
        }

        return null;
    }
}