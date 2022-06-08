using UnityEngine;
using UnityEngine.UI;

public class TypeDisplay : MonoBehaviour
{
    [SerializeField] private Image _imgIcon;

    public void SetType(DetectionType pType)
    {
        if(pType.icon != null) _imgIcon.sprite = pType.icon;
        _imgIcon.color = pType.color;
    }
}