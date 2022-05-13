using UnityEngine;
using TMPro;

public class TypeDisplay : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private TextMeshProUGUI _txtTypeName;

    public void DisplayMaterial(DetectionType pType)
    {
        if (!isTypeValid(pType) || _meshRenderer == null) return;

        _meshRenderer.sharedMaterial = pType.material;
    }

    public void DisplayName(DetectionType pType)
    {
        if (!isTypeValid(pType) || _txtTypeName == null) return;

        _txtTypeName.text = pType.typeName;
    }

    public void DisplayInformation(DetectionType pType)
    {
        if (!isTypeValid(pType)) return;

        DisplayMaterial(pType);
        DisplayName(pType);
    }

    private bool isTypeValid(DetectionType pType)
    {
        if(pType == null)
        {
            DebugUtil.Log($"Sorting type is invalid in '{nameof(isTypeValid)}' on '{nameof(TypeDisplay)}'. Source object: '{gameObject.name}'.", LogType.ERROR);
            return false;
        }
        
        return true;
    }
}
