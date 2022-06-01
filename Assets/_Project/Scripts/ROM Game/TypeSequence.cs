using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TypeSequence : MonoBehaviour
{
    [field: SerializeField] public int queueSize { get; private set; }
    [SerializeField] private DetectionType[] _possibleTypes;
    [field: SerializeField] public UnityEvent<DetectionType> onActiveTypeChanged { get; private set; }

    public List<DetectionType> types { get; private set; } = new List<DetectionType>();

    private void Start()
    {
        fill();
        Next();
    }

    private void fill()
    {
        while (types.Count < queueSize)
        {
            types.Add(getRandomType());
        }
    }

    public void Next()
    {
        types.RemoveAt(0);
        fill();
        onActiveTypeChanged?.Invoke(types[0]);
    }

    private DetectionType getRandomType()
    {
        int index = Random.Range(0, _possibleTypes.Length);

        return _possibleTypes[index];
    }
}
