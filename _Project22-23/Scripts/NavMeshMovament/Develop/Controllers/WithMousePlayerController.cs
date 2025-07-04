using System.Collections.Generic;
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class WithMousePlayerController : Controller
    {
        private const float MinDistanceToTarget = 0.1f;
        private const int LeftMouseButton = 0;

        private IDirectionalMovable _movable;
        private ClickGroundHandler _clickGroundHandler;
        private Camera _camera;
        private Vector3 _targetPosition;
        private Vector3 _direction;
        private Queue<Vector3> _path;

        public WithMousePlayerController(IDirectionalMovable movable, ClickGroundHandler clickGroundHandler)
        {
            _movable = movable;
            _clickGroundHandler = clickGroundHandler;
            _camera = Camera.main;
            _targetPosition = _movable.Transform.position;
            _path = new Queue<Vector3>();
        }

        private bool IsPresedLeftMouseButton() => Input.GetMouseButtonDown(LeftMouseButton);

        protected override void UpdateLogic(float deltaTime)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (IsPresedLeftMouseButton() && _clickGroundHandler.TryGetPath(ray, out List<Vector3> path))
                SetPath(path);

            _direction = Vector3.zero;

            if (IsReachedTarget(_targetPosition) == false)
                _direction = GetDirection(_targetPosition);
            else
            {
                if (_path.Count > 0)
                {
                    _targetPosition = GetNextPoint();
                    _direction = GetDirection(_targetPosition);
                }
            }

            _movable.SetMoveDirection(_direction);
        }

        private void SetPath(List<Vector3> path)
        {
            _path.Clear();

            foreach (Vector3 point in path)
                _path.Enqueue(point);

            _targetPosition = GetNextPoint();
        }
       
        private Vector3 GetNextPoint()
            => _path.Dequeue();

        private Vector3 GetDirection(Vector3 target)
            => (target - _movable.Transform.position).normalized;

        private bool IsReachedTarget(Vector3 target)
            => Vector3.Distance(_movable.Transform.position, target) <= MinDistanceToTarget;
    }
}