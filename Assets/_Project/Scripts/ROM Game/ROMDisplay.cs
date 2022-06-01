using UnityEngine;
using UnityEngine.UI;

public class ROMDisplay : MonoBehaviour
{
    [SerializeField] private Image _imgIcon;

    public void SetType(ROMType pType)
    {
        if(pType.icon != null) _imgIcon.sprite = pType.icon;
        _imgIcon.color = pType.color;
    }
}