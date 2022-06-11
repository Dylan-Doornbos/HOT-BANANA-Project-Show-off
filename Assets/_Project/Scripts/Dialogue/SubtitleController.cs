using System;
using TMPro;
using UnityEngine;

public class SubtitleController : MonoBehaviour
{
    public static SubtitleController instance;
    
    [SerializeField] private GameObject _container;
    [SerializeField] private TextMeshProUGUI _txtSubtitles;

    private void Awake()
    {
        instance = this;
        
        if (_txtSubtitles == null)
            DebugUtil.Log($"'{nameof(_txtSubtitles)}' is not assigned on '{gameObject.name}'.", LogType.ERROR);
    }

    public void SetLine(string pLine)
    {
        Show();
        _txtSubtitles.text = pLine;
    }

    public void Show()
    {
        if(!_container.activeSelf) _container.SetActive(true);
    }

    public void Stop()
    {
        if(_container != null) _container.SetActive(false);
    }
}
