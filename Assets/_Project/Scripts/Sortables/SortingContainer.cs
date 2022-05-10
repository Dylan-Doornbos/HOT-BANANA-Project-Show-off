using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortingContainer : MonoBehaviour
{
    [SerializeField] private List<SortingType> _sortingTypes;
    [Space]
    [SerializeField] private UnityEvent _onCorrectSort;
    [SerializeField] private UnityEvent _onIncorrectSort;

	public void Sort(Sortable pSortable)
    {
        if (pSortable == null || pSortable.sortingType == null) return;

		if (_sortingTypes.Contains(pSortable.sortingType))
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
}