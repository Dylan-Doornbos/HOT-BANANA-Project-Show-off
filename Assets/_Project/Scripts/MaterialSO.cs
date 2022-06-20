using UnityEngine;

[CreateAssetMenu(menuName = "Data/Material")]
public class MaterialSO : ScriptableObject
{
    [field: SerializeField] public Material material { get; private set; }
}