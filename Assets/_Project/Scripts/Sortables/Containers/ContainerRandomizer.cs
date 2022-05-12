using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerRandomizer : MonoBehaviour
{
    [SerializeField] private List<SortingContainer> _containersToRandomize;
    [SerializeField] private List<SortingType> _possibleTypes;
    [Tooltip("False = Generate random types per container.\nTrue = Generate 1 random type for all containers.")]
    [SerializeField] private bool _randomizeContainersSeparately;

    private void Awake()
    {
        if (_containersToRandomize == null || _containersToRandomize.Count == 0)
        {
            DebugUtil.Log($"No containers were specified for '{nameof(_containersToRandomize)}'. Source object: '{gameObject.name}'.", LogType.WARNING);
        }

        if (_possibleTypes == null || _possibleTypes.Count == 0)
        {
            DebugUtil.Log($"No possible types were specified in '{nameof(_possibleTypes)}'. Source object: '{gameObject.name}'.", LogType.WARNING);
        }
    }

    /// <summary>
    /// Randomizes the sorting type of the stored containers.
    /// </summary>
    public void Randomize()
    {
        if (_containersToRandomize == null || _containersToRandomize.Count == 0
            || _possibleTypes == null || _possibleTypes.Count == 0)
        {
            return;
        }

        SortingType type = getRandomType();

        foreach (SortingContainer container in _containersToRandomize)
        {
            //Randomize the type for each container if specified.
            if(_randomizeContainersSeparately)
            {
                type = getRandomType();
                if (type == null) continue;
            }

            container.SetSortingTypes(type);
        }
    }

    /// <summary>
    /// Gets a random type from the list of possible types
    /// </summary>
    /// <returns></returns>
    private SortingType getRandomType()
    {
        int index = Random.Range(0, _possibleTypes.Count);
        SortingType type = _possibleTypes[index];
        
        if(type == null)
        {
            DebugUtil.Log($"Randomized type is invalid in '{nameof(getRandomType)}' on '{nameof(ContainerRandomizer)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return null;
        }

        return type;
    }
}
