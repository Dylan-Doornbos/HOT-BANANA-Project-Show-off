using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MovingBeam : MonoBehaviour
{
    private Vector3 _pointA;
    private Vector3 _pointB;
    [SerializeField] private float _moveDistance = 2;
    [FormerlySerializedAs("_randomPosition")] [SerializeField] private bool _randomisePosition;
    [SerializeField] [Min(0.1f)] private float _moveSpeed;

    private Tweener _moveTween;

    private void OnDrawGizmos()
    {
        Vector3 pointA = transform.position;
        Vector3 pointB = transform.position + transform.right * _moveDistance;

        Gizmos.DrawLine(pointA, pointB);
    }

    private void Awake()
    {
        _pointA = transform.position;
        _pointB = transform.position + transform.right * _moveDistance;
    }

    public void Begin()
    {
        goToNextPosition();
        _moveTween.timeScale = 0;
        _moveTween.DOTimeScale(1, 1f);
    }

    public void Stop()
    {
        _moveTween.DOTimeScale(0, 1f)
            .OnComplete(() =>
            {
                _moveTween.Kill();
            });
    }

    private void goToNextPosition()
    {
        if(_pointA == null || _pointB == null) return;
        
        Vector3 position = _pointA;

        if (_randomisePosition)
        {
            position = randomPosition();
        }
        else
        {
            position = nextPosition();
        }

        position = applyMinDistance(position);

        float distance = (transform.position - position).magnitude;
        float moveDuration = distance / _moveSpeed;

        _moveTween = transform.DOMove(position, moveDuration)
            .SetEase(Ease.Linear)
            .OnComplete(goToNextPosition);
    }

    private Vector3 nextPosition()
    {
        float distanceToA = (transform.position - _pointA).magnitude;

        return distanceToA < 0.1f ? _pointB : _pointA;
    }

    private Vector3 randomPosition()
    {
        float rnd = Random.Range(0, 1f);
        Vector3 position = Vector3.Lerp(_pointA, _pointB, rnd);
        return position;
    }

    private Vector3 applyMinDistance(Vector3 pDestination)
    {
        Vector3 movement = pDestination - transform.position;

        if (movement.magnitude < 0.5f)
        {
            movement = movement.normalized * 0.5f;
        }

        return transform.position + movement;
    }

    public void SetSpeed(float pSpeed)
    {
        _moveSpeed = Mathf.Clamp(pSpeed, 0.1f, Mathf.Infinity);
    }

    public void SetEnabledState(bool pIsEnabled)
    {
        gameObject.SetActive(pIsEnabled);
    }

    public void SetMoveBehaviour(bool pIsRandom)
    {
        _randomisePosition = pIsRandom;
    }
}
