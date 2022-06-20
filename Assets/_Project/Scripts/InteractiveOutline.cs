using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveOutline : MonoBehaviour
{
    [SerializeField] private MaterialSO _outlineMaterial;

    private List<XRBaseInteractor> _interactors;

    private List<Type> _excludedTypes = new List<Type>()
    {
        typeof(TeleportationArea)
    };

    private void Awake()
    {
        _interactors = FindObjectsOfType<XRBaseInteractor>().ToList();
    }

    private void OnEnable()
    {
        _interactors.ForEach(x => x.hoverEntered.AddListener(onHoverEnter));
        //_interactors.ForEach(x => x.hoverExited.AddListener(onHoverExit));
    }

    private void OnDisable()
    {
        _interactors.ForEach(x => x.hoverEntered.RemoveListener(onHoverEnter));
        _interactors.ForEach(x => x.hoverExited.RemoveListener(onHoverExit));
    }

    private void onHoverEnter(HoverEnterEventArgs pArgs)
    {
        if (isExcludedType(pArgs.interactableObject)) return;
        if (!tryGetRenderers(pArgs.interactableObject, out MeshRenderer[] renderers)) return;

        foreach (MeshRenderer renderer in renderers)
        {
            List<Material> materials = renderer.sharedMaterials.ToList();

            if (materials.Contains(_outlineMaterial.material)) continue;

            materials.Add(_outlineMaterial.material);

            renderer.sharedMaterials = materials.ToArray();
        }
    }

    private void onHoverExit(HoverExitEventArgs pArgs)
    {
        if (isExcludedType(pArgs.interactableObject)) return;
        if (!tryGetRenderers(pArgs.interactableObject, out MeshRenderer[] renderers)) return;

        foreach (MeshRenderer renderer in renderers)
        {
            List<Material> materials = renderer.sharedMaterials.ToList();

            if (!materials.Contains(_outlineMaterial.material)) continue;

            materials.Remove(_outlineMaterial.material);

            renderer.sharedMaterials = materials.ToArray();
        }
    }

    private bool isExcludedType(object pObject)
    {
        foreach (Type type in _excludedTypes)
        {
            if (pObject.GetType() == type) return true;
        }

        return false;
    }

    private bool tryGetRenderers(IXRHoverInteractable pInteractable, out MeshRenderer[] pRenderers)
    {
        pRenderers = null;

        if (!(pInteractable is MonoBehaviour interactable)) return false;

        pRenderers = interactable.GetComponentsInChildren<MeshRenderer>();
        return true;
    }
}