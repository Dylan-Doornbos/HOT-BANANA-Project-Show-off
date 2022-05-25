using UnityEngine;

[RequireComponent(typeof(Movement))]
public class RotateWithMovement : MonoBehaviour
{
    private Movement _movement;
    [SerializeField] private bool _lookUpDown;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        _movement.onDestinationChanged.AddListener(rotateTowardsDirection);
    }

    private void OnDisable()
    {
        _movement.onDestinationChanged.RemoveListener(rotateTowardsDirection);
    }

    private void rotateTowardsDirection(Vector3 pDirection)
    {
        pDirection.y = _lookUpDown ? pDirection.y : 0;
        
        transform.forward = pDirection.normalized;
    }
}
