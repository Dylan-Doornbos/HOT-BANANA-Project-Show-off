using UnityEngine;

[CreateAssetMenu(menuName = "Detectables/Default")]
public class DetectionType : ScriptableObject
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] public Color color { get; private set; } = Color.white;
}