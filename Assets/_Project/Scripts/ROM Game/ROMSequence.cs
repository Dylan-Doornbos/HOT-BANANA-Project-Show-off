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

    private void Awake()
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
        ROMType poppedType = types[0];
        types.RemoveAt(0);
        
        onActiveTypeChanged?.Invoke(poppedType);
        fill();
    }

    private ROMType getRandomType()
    {
        int index = Random.Range(0, _possibleTypes.Length);

        return _possibleTypes[index];
    }
}
