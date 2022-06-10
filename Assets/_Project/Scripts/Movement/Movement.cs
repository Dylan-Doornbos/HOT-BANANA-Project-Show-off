using UnityEngine;
using UnityEngine.Events;

public abstract class Movement : MonoBehaviour
{
    [field: SerializeField] public UnityEvent onDestinationReached { get; } = new UnityEvent();
    [field: SerializeField] public UnityEvent<Vector3> onDestinationChanged { get; } = new UnityEvent<Vector3>();
    public abstract float moveSpeed { get; }

    public void MoveToPosition(Vector3 pPosition)
    {
        moveToPosition(pPosition);
        onDestinationChanged?.Invoke(pPosition - transform.position);
    }

    protected abstract void moveToPosition(Vector3 pPosition);
    
    public abstract void SetPosition(Vector3 pPosition);
}
