using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ROMSequence : MonoBehaviour
{
    [field: SerializeField] public int queueSize { get; private set; }
    [SerializeField] private ROMType[] _possibleTypes;
    [field: SerializeField] public UnityEvent<ROMType> onActiveTypeChanged { get; private set; }

    public List<ROMType> types { get; private set; } = new List<ROMType>();

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

    private ROMType getRandomType()
    {
        int index = Random.Range(0, _possibleTypes.Length);

        return _possibleTypes[index];
    }
}
