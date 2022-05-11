using UnityEngine;
using TMPro;

public class DisplayTypeInformation : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private TextMeshProUGUI _txtTypeName;

    public void DisplayMaterial(SortingType pType)
    {
        if (!isTypeValid(pType) || _meshRenderer == null) return;

        _meshRenderer.sharedMaterial = pType.material;
    }

    public void DisplayName(SortingType pType)
    {
        if (!isTypeValid(pType) || _txtTypeName == null) return;

        _txtTypeName.text = pType.typeName;
    }

    public void DisplayAll(SortingType pType)
    {
        if (!isTypeValid(pType)) return;

        DisplayMaterial(pType);
        DisplayName(pType);
    }

    private bool isTypeValid(SortingType pType)
    {
        if(pType == null)
        {
            DebugUtil.Log($"Sorting type is invalid in '{nameof(isTypeValid)}' on '{nameof(DisplayTypeInformation)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return false;
        }
        
        return true;
    }
}
