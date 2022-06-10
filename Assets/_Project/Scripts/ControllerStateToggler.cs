using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerStateToggler : MonoBehaviour
{
    [SerializeField] private XRRayInteractor[] _interactors;

    public void SetState(InteractionLayerMaskSO pMask)
    {
        foreach (XRRayInteractor interactor in _interactors)
        {
            interactor.interactionLayers = pMask.layerMask;
        }
    }
}
