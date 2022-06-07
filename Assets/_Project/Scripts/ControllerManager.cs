using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractor))]
public class ControllerManager : MonoBehaviour
{
    private XRBaseInteractor _interactor;

    private void Awake()
    {
        _interactor = GetComponent<XRBaseInteractor>();
    }

    public void CancelInteraction()
    {
        StartCoroutine(cancelInteraction());
    }

    private IEnumerator cancelInteraction()
    {
        _interactor.allowSelect = false;
        
        yield return null;
        
        _interactor.allowSelect = true;
    }
}