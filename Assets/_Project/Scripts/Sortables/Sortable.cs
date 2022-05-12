using UnityEngine;

public class Sortable : MonoBehaviour
{
    [field: SerializeField] public SortingType sortingType { get; private set; }

    private void Awake()
    {
        if (sortingType == null) DebugUtil.Log($"{sortingType.name} is not defined on {gameObject.name}", LogType.ERROR);
    }
}