using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rotator))]
public class RotateInteractor<T> : XRBaseInteractable where T : Rotator
{
    [SerializeField] GameObject _hitArea;

    private XRRayInteractor _interactor = null;
    private List<Collider> _childColliders = new List<Collider>();
    protected T _rotator;

    private string _invalidRotatorError => string.Format("Object of type '{0}' could not be found on game object '{1}'.", typeof(T), gameObject.name);

    protected override void Awake()
    {
        base.Awake();
        _rotator = GetComponent<T>();

        if (_rotator == null)
        {
            DebugUtil.Log(_invalidRotatorError, LogType.ERROR);
        }

        _childColliders = GetComponentsInChildren<Collider>().ToList();
        _childColliders.AddRange(GetComponents<Collider>());
    }

    protected virtual void Update()
    {
        if (_interactor == null) return;
        if (!_interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) return;
        if (_hitArea != null && _hitArea != hit.collider.gameObject) return;

        Vector3 lookDirection = hit.point - transform.position;

        _rotator.SetRotation(lookDirection);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _interactor = args.interactorObject as XRRayInteractor;
        toggleColliders(false);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        _interactor = null;
        toggleColliders(true);
    }

    /// <summary>
    /// Toggles all the colliders on the child objects.
    /// </summary>
    /// <param name="pAreEnabled"></param>
    private void toggleColliders(bool pAreEnabled)
    {
        if (_childColliders == null || _childColliders.Count == 0) return;

        foreach(Collider collider in _childColliders)
        {
            collider.enabled = pAreEnabled;
        }
    }
}
