using TMPro;
using UnityEngine;

public class CounterTextUI : MonoBehaviour
{
    [SerializeField] Counter _counter;
    [SerializeField] TextMeshProUGUI _txtCounter;

    private void Awake()
    {
        if (_counter == null)
        {
            DebugUtil.Log($"'{nameof(_counter)}' is not assigned for '{typeof(CounterTextUI)}' on '{gameObject.name}'.", LogType.ERROR);
        }
        else
        {
            _counter.onCounterIncreased.AddListener(updateUI);
        }
    }

    private void updateUI()
    {
        if (_txtCounter == null) return;

        _txtCounter.text = _counter.count.ToString();
    }
}
