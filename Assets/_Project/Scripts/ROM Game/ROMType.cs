using UnityEngine;

[CreateAssetMenu(menuName = "Detectables/ROM")]
public class ROMType : DetectionType
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] public Color color { get; private set; } = Color.white;
}
