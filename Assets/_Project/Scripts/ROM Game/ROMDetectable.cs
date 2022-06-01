using UnityEngine;
using UnityEngine.UI;

public class ROMDetectable : GenericDetectable<ROMType>
{
    [Header("Optional")]
    [SerializeField] private Image _iconUI;
    
    protected override void Awake()
    {
        base.Awake();
        if (TryGetComponent(out MeshRenderer renderer))
        {
            renderer.sharedMaterial.color = detectionType.color;
        }

        if (_iconUI != null) _iconUI.sprite = detectionType.icon;
    }
}
