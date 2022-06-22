using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RTCDials : MonoBehaviour
{
    [SerializeField] GameEvent _onGameStarted;
    [SerializeField] GameEvent _onGameFinished;

    [SerializeField] private List<Dial> _dials;

    private void Awake()
    {
        if (_onGameStarted == null || _onGameFinished == null)
        {
            DebugUtil.Log($"Null references for '{nameof(RTCDials)}' on '{gameObject.name}'.", LogType.ERROR);
        }

        if (_dials == null || _dials.Count == 0)
        {
            _dials = GetComponentsInChildren<Dial>().ToList();
        }
    }

    private void OnEnable()
    {
        _onGameStarted.AddListener(enable);
        _onGameFinished.AddListener(disable);
    }

    private void OnDisable()
    {
        _onGameStarted.RemoveListener(enable);
        _onGameFinished.RemoveListener(disable);
    }

    private void enable()
    {
        setActive(true);
    }

    private void disable()
    {
        setActive(false);
    }

    private void setActive(bool pIsActive)
    {
        _dials.ForEach(x => x.enabled = pIsActive);
    }
}