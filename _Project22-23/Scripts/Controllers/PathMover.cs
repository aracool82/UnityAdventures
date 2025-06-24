using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public class PathMover : DirectionMover
    {
        private Queue<Vector3> _path;
        private float _minDistance;
        private Vector3 _currentPoint;
        
        public PathMover(CharacterController characterController, float movementSpeed) 
            : base(characterController,movementSpeed)
        {
            _path = new Queue<Vector3>();
            _minDistance = 0.1f;
        }
        
        public bool IsMovementCoplite => Direction == Vector3.zero;
        
        public void SetPath(NavMeshPath path)
        {
            if (path == null)
            {
                Debug.LogError("Path is null");
                return;
            }

            _path.Clear();

            foreach (Vector3 corner in path.corners)
                _path.Enqueue(corner);

            if (_path.Count > 0)
                _currentPoint = GetPoint();
        }

        public override void Update(float deltaTime)
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

            base.Update(deltaTime);
        }

        private Vector3 GetDirection()
            => (_currentPoint - CharacterController.transform.position).normalized;

        private Vector3 GetPoint()
            => _path.Dequeue();

        private bool IsReachedPoint()
            => (Vector3.Distance(CharacterController.transform.position, _currentPoint) < _minDistance);
    }
}