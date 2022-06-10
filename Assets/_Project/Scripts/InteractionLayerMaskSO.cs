using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[CreateAssetMenu(menuName = "Scriptables/Interaction Layer Mask")]
public class InteractionLayerMaskSO : ScriptableObject
{
    [field: SerializeField] public InteractionLayerMask layerMask { get; private set; }
}
