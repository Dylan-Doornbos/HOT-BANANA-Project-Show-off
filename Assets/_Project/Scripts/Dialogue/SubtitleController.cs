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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        if (_txtSubtitles == null)
            DebugUtil.Log($"'{nameof(_txtSubtitles)}' is not assigned on '{gameObject.name}'.", LogType.ERROR);
    }

    public void SetLine(string pLine)
    {
        if (!_container.activeSelf) _container.SetActive(true);

        _txtSubtitles.text = pLine;
    }

    public void Hide()
    {
        _container.SetActive(false);
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }
}
