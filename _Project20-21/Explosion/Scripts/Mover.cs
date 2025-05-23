using System.Collections;
using UnityEngine;

public class Mover
{
    private Transform _source;
    private Transform _target;
    private AnimationCurve _moveCurve;
    private MonoBehaviour _monoBehaviour;
    private Coroutine _moveCoroutine;
    
    private bool _isMoving = true;
    
    public Mover(MonoBehaviour monoBehaviour ,AnimationCurve moveCurve,Transform source)
    {
        _monoBehaviour = monoBehaviour;
        _moveCurve = moveCurve;
        _source = source;
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

        _moveCoroutine = _monoBehaviour.StartCoroutine(ProcessMove(target));
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
}