using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Sorting Type")]
public class DetectionType : ScriptableObject
{
    [field: SerializeField] public string typeName { get; private set; }
    [field: SerializeField] public Material material { get; private set; }
}