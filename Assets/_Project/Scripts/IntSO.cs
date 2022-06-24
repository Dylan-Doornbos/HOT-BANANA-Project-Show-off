using UnityEngine;

[CreateAssetMenu(menuName = "Data/Int")]
public class IntSO : ScriptableObject
{
    [field: SerializeField] public int value { get; private set; }
}
