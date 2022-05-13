using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateInteractor : XRBaseInteractable
{
    [Tooltip("Rotation is in local space")]
    [SerializeField] RotationMode _rotationAxis;
    [SerializeField] GameObject _hitArea;

    private XRRayInteractor _interactor = null;
    private Quaternion _originalRotation;

    protected override void Awake()
    {
        base.Awake();
        _originalRotation = transform.localRotation;
    }

    private void Update()
    {
        if (_interactor == null) return;
        if (!_interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) return;
        if (_hitArea != null && _hitArea != hit.collider.gameObject) return;

        var lookPos = hit.point - transform.position;

        switch (_rotationAxis)
        {
            case RotationMode.xAxis:
                lookPos.x = 0;
                break;
            case RotationMode.yAxis:
                lookPos.y = 0;
                break;
            case RotationMode.zAxis:
                lookPos.z = 0;
                break;
        }

        var rotation = Quaternion.LookRotation(lookPos);
        rotation = rotation * _originalRotation;

        transform.localRotation = Quaternion.Slerp(transform.rotation, rotation, 0.8f);
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

    public enum RotationMode
    {
        xAxis,
        yAxis,
        zAxis
    }
}
