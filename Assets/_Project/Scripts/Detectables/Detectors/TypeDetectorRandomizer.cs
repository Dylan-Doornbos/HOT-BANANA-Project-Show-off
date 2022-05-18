using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypeDetectorRandomizer : MonoBehaviour
{
    [SerializeField] private List<TypeDetector> _detectorsToRandomize;
    [SerializeField] private List<DetectionType> _possibleTypes;
    [Tooltip("False = Generate random types per container.\nTrue = Generate 1 random type for all containers.")]
    [SerializeField] private bool _randomizeContainersSeparately;

    private void Awake()
    {
        if (_detectorsToRandomize == null || _detectorsToRandomize.Count == 0)
        {
            DebugUtil.Log($"No detectors were specified for '{nameof(_detectorsToRandomize)}'. Source object: '{gameObject.name}'.", LogType.WARNING);
        }

        if (_possibleTypes == null || _possibleTypes.Count == 0)
        {
            DebugUtil.Log($"No possible types were specified in '{nameof(_possibleTypes)}'. Source object: '{gameObject.name}'.", LogType.WARNING);
        }
    }

    /// <summary>
    /// Randomizes the detection type of the stored containers.
    /// </summary>
    public void Randomize()
    {
        if (_detectorsToRandomize == null || _detectorsToRandomize.Count == 0
            || _possibleTypes == null || _possibleTypes.Count == 0)
        {
            return;
        }

        DetectionType type = getRandomType();

        foreach (TypeDetector container in _detectorsToRandomize)
        {
            //Randomize the type for each container if specified.
            if(_randomizeContainersSeparately)
            {
                type = getRandomType();
                if (type == null) continue;
            }

            container.SetDetectionType(type);
        }
    }

    /// <summary>
    /// Gets a random type from the list of possible types
    /// </summary>
    /// <returns></returns>
    private DetectionType getRandomType()
    {
        int index = Random.Range(0, _possibleTypes.Count);
        DetectionType type = _possibleTypes[index];
        
        if(type == null)
        {
            DebugUtil.Log($"Randomized type is invalid in '{nameof(getRandomType)}' on '{nameof(TypeDetectorRandomizer)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return null;
        }

        return type;
    }
}
