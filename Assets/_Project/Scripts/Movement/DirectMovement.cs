using DG.Tweening;
using UnityEngine;

public class DirectMovement : Movement
{
    public override float moveSpeed => (_previousPosition - transform.position).magnitude / Time.deltaTime;

    [SerializeField] float _moveSpeed;

    private Tween _moveTween;
    
    private Vector3 _previousPosition = Vector3.zero;

    private void Update()
    {
        _previousPosition = transform.position;
    }

    protected override void moveToPosition(Vector3 pPosition)
    {
        Vector3 movement = pPosition - transform.position;
        float duration = movement.magnitude/ _moveSpeed;
        
        _moveTween.Kill();

        transform.DOMove(pPosition, duration)
            .SetEase(Ease.Linear)
            .OnComplete(onDestinationReached.Invoke);

        //TODO: Fancy animations?
    }

    public override void SetPosition(Vector3 pPosition)
    {
        transform.position = pPosition;
    }
}