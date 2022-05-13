using UnityEngine;
using UnityEngine.Events;

public class SortingContainer : MonoBehaviour
{
    [SerializeField] private SortingType _sortingType;
    [Space]
    [SerializeField] private UnityEvent _onCorrectSort;
    [SerializeField] private UnityEvent _onIncorrectSort;
    [SerializeField] private UnityEvent<SortingType> _onTypeChanged;

    //TODO: Error Handling
    //TODO: Implement onTrigger detection

    public void Sort(Sortable pSortable)
    {
        if (pSortable == null || pSortable.sortingType == null) return;

        if (_sortingType == pSortable.sortingType)
        {
            _onCorrectSort?.Invoke();
        }
        else
        {
            _onIncorrectSort?.Invoke();
        }
    }

    public void Sort(GameObject obj)
    {
        Sortable sortable = obj.GetComponent<Sortable>();

        if (sortable == null) return;

        Sort(sortable);
    }

    public void SetSortingTypes(SortingType pSortingType)
    {
        if (pSortingType == null)
        {
            DebugUtil.Log($"Specified list of sorting types is invalid in '{nameof(SetSortingTypes)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return;
        }

        _sortingType = pSortingType;
        _onTypeChanged?.Invoke(pSortingType);
    }
}