using UnityEngine;
using UnityEngine.UI;

public class DetectableType : Detectable
{
    [SerializeField] private bool _overrideMaterialColor = false;
    [Header("Optional")]
    [SerializeField] private Image _iconUI;
    
    protected void Awake()
    {
        if (TryGetComponent(out MeshRenderer renderer))
        {
            Material material = renderer.sharedMaterial;
            material.color = type.color;
            renderer.material = material;
        }

        if (_iconUI != null) _iconUI.sprite = type.icon;
    }
}
