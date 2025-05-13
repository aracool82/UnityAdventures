using System.Collections.Generic;
using UnityEngine;

namespace Progec10_11
{
    public class PointToPointMover : Mover
    {
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Transform[] _transforms;

        private Queue<Vector3> _points = new Queue<Vector3>();
        private Vector3 _currentTarget;
        private float _minDistanceToTarget = 0.1f;
        private bool _canMove;

        private void Awake()
        {
            if (_transforms.Length == 0)
                Debug.LogError("Transforms not found!");

            foreach (Transform point in _transforms)
                _points.Enqueue(point.position);

            _canMove = false;
            _currentTarget = GetTarget();
        }

        private void Update()
        {
            if (_canMove == false)
                return;

            if (IsReachedTarget())
                _currentTarget = GetNextTarget();

            _rotator.RotationToTarget(_currentTarget);
            Move(GetDirection());
        }

        public void StopMovement()
            => _canMove = false;

        public void StartMovement()
            => _canMove = true;

        private bool IsReachedTarget()
            => (transform.position - _currentTarget).magnitude <= _minDistanceToTarget;

        private Vector3 GetDirection()
            => (_currentTarget - transform.position).normalized;

        private Vector3 GetNextTarget()
            => GetTarget();

        private Vector3 GetTarget()
        {
            Vector3 target = _points.Dequeue();
            _points.Enqueue(target);

            return target;
        }
    }
}