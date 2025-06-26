using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public class CompositeController
    {
        private DirectionMover _directionMover;
        private DirectionRotator _directionRotator;
        private Transform _characterTransform;

        private Queue<Vector3> _path;
        private Vector3 _currentPoint;
        private float _minDistance;

        public CompositeController(DirectionMover directionMover, DirectionRotator directionRotator,
            Transform characterTransform)
        {
            _directionMover = directionMover;
            _directionRotator = directionRotator;
            _characterTransform = characterTransform;
            _minDistance = 0.1f;
            _path = new Queue<Vector3>();
        }

        public Vector3 Velocity => _directionMover.Velocity;
        public bool IsMoving => _directionMover.IsMoving;

        public void SetPath(NavMeshPath path)
        {
            if (path == null)
            {
                Debug.LogError("Path is null");
                return;
            }

            _path.Clear();

            if (path.corners.Length > 1)
                for (int i = 1; i < path.corners.Length; i++)
                    _path.Enqueue(path.corners[i]);
            else
                Debug.LogError("Path is invalid");

            if (_path.Count > 0)
            {
                _currentPoint = _path.Dequeue();
                SetDirection(GetDirection());
            }
        }

        public void Update(float deltaTime)
        {
            if (IsReachedPoint())
            {
                if (_path.Count > 0)
                {
                    _currentPoint = GetPoint();
                    SetDirection(GetDirection());
                }
                else
                {
                    SetDirection(Vector3.zero);
                }
            }

            _directionMover.Update(deltaTime);
            _directionRotator.Update(deltaTime);
        }

        private void SetDirection(Vector3 direction)
        {
            _directionMover.SetDirection(direction);
            _directionRotator.SetDirection(direction);
        }

        private Vector3 GetDirection()
            => (_currentPoint - _characterTransform.position).normalized;

        private Vector3 GetPoint()
            => _path.Dequeue();

        private bool IsReachedPoint()
            => (Vector3.Distance(_characterTransform.position, _currentPoint) <= _minDistance);
    }
}