using System.Collections;
using UnityEngine;

public class Mover
{
    private const float MinDistanceToTarget = 0.1f;

    private Transform _source;
    private Transform _target;
    private float _speed;
    private AnimationCurve _moveCurve;
    private MonoBehaviour _box;
    private bool _isMoving = true;
    private Coroutine _moveCoroutine;
    
    public Mover(MonoBehaviour box ,AnimationCurve moveCurve,Transform source, float speed)
    {
        _box = box;
        _moveCurve = moveCurve;
        _source = source;
        _speed = speed;
    }

    public void MoveTo(Transform target)
    {
        if (target == null)
        {
            Debug.Log("Target is null");
            return;
        }
        
        if(_isMoving == false)
            return;

        _moveCoroutine = _box.StartCoroutine(ProcessMove(target));
    }

    private IEnumerator ProcessMove(Transform target)
    {
        _isMoving = false;
        float progress = 0;
        float endProgress = 0.5f;


        while (progress <= endProgress)
        {
            progress += Time.deltaTime;
            _source.position = Vector3.LerpUnclamped(_source.position, target.position, _moveCurve.Evaluate(progress));
            Debug.Log("Progress " + progress);
            yield return null;
        }

        Debug.Log("ProcessMove ---- finished -----");
        _moveCoroutine = null;
        _isMoving = true;
    }

    private bool IsReachedTarget(Vector3 target)
        => Vector3.Distance(target,_source.position) < MinDistanceToTarget;

    private Vector3 GetDirection()
        => _target.position - _source.position;
}