using UnityEngine;
using UnityEngine.UI;

public class DetectableType : Detectable
{
    [Header("Optional")]
    [SerializeField] private Image _iconUI;
    
    protected void Awake()
    {
        if (_iconUI != null) _iconUI.sprite = type.icon;
    }
}
