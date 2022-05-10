using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Sorting Type")]
public class SortingType : ScriptableObject
{
    [field: SerializeField] public string typeName { get; private set; }
}