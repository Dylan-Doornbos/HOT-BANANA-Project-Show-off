using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateInteractor : XRBaseInteractable
{
    [SerializeField] GameObject _hitArea;

    private XRRayInteractor _interactor = null;
    protected Vector3 rotateAxis;
    private Vector3 rightDirection;

    protected override void Awake()
    {
        base.Awake();
        rotateAxis = -transform.right;
        rightDirection = transform.forward;
    }

    //TODO: Disable all colliders while rotating the object

    protected virtual void Update()
    {
        if (_interactor == null) return;
        if (!_interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) return;
        if (_hitArea != null && _hitArea != hit.collider.gameObject) return;

        Vector3 lookDirection = hit.point - transform.position;

        float dot = Vector3.Dot(lookDirection, rotateAxis);

        lookDirection -= dot * rotateAxis;

        Vector3 newUp = Quaternion.AngleAxis(90, rotateAxis) * lookDirection;

        transform.rotation = Quaternion.LookRotation(lookDirection, newUp);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _interactor = args.interactorObject as XRRayInteractor;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        _interactor = null;
    }
}
