using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateInteractor : XRBaseInteractable
{
    [SerializeField] GameObject _hitArea;

    private XRRayInteractor _interactor = null;
    protected Vector3 _rotateAxis;
    protected Vector3 _forwardDirection;

    protected override void Awake()
    {
        base.Awake();
        _rotateAxis = -transform.right;
        _forwardDirection = transform.forward;
    }

    //TODO: Disable all colliders while rotating the object

    protected virtual void Update()
    {
        if (_interactor == null) return;
        if (!_interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) return;
        if (_hitArea != null && _hitArea != hit.collider.gameObject) return;

        Vector3 lookDirection = hit.point - transform.position;

        float dot = Vector3.Dot(lookDirection, _rotateAxis);

        lookDirection -= dot * _rotateAxis;

        Vector3 newUp = Quaternion.AngleAxis(90, _rotateAxis) * lookDirection;

        transform.rotation = Quaternion.LookRotation(lookDirection, newUp);
    }

    public void SetRotation(Vector3 pLookDirection)
    {
        float dot = Vector3.Dot(pLookDirection, _rotateAxis);
        pLookDirection -= dot * _rotateAxis;
        Vector3 newUp = Quaternion.AngleAxis(90, _rotateAxis) * pLookDirection;

        transform.rotation = Quaternion.LookRotation(pLookDirection, newUp);
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
