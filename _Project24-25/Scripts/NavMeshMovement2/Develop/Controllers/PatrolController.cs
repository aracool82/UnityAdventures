using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    public class PatrolController : Controller
    {
        private const float MinDistanceToTarget = 0.1f;

        private IDirectionalMovable _movable;
        private Transform _marker;
        private float _timeToChangePoint;
        private float _radius;
        private Queue<Vector3> _patrolPath;
        private Vector3 _targetPosition;
        private Vector3 _direction;

        private NavMeshPath _path;
        private NavMeshQueryFilter _filter;

        private float _timer;

        public PatrolController(IDirectionalMovable movable, Transform marker, float timeToChangePoint, float radius)
        {
            _movable = movable;
            _marker = marker;
            _timeToChangePoint = timeToChangePoint;
            _radius = radius;
            _path = new NavMeshPath();
            _filter = new NavMeshQueryFilter();
            _filter.areaMask = NavMesh.AllAreas;
            _filter.agentTypeID = 0;
            _patrolPath = new Queue<Vector3>();
            _targetPosition = _movable.Transform.position;
        }

        private bool IsMoved => _movable.CurrentVelocity != Vector3.zero;

        protected override void UpdateLogic(float deltaTime)
        {
            _timer += deltaTime;
            _direction = Vector3.zero;
            Debug.DrawRay(_movable.Transform.position + new Vector3(0,0.5f,0), _movable.CurrentVelocity , Color.yellow);

            if (_timer >= _timeToChangePoint && IsMoved == false)
            {
                _timer = 0;
                Vector3 point;
                int tryCouter = 20;

                do
                {
                    tryCouter--;
                    point = GetRandomPointInRadius();
                } while (NavMeshUtills.TryGetPath(_movable.Transform.position, point, _filter, _path) == false &&
                         tryCouter != 0);

                if (tryCouter == 0)
                {
                    //_targetPosition = _movable.Transform.position;
                    Debug.Log("No path found.You can increase tryCounter");
                }
                else
                {
                    SetPath(_path);
                    SetMarkerAtLastPoint(_path);
                }

                _targetPosition = GetNextPoint();
            }

            if (IsReachedTarget(_targetPosition) == false)
            {
                _direction = GetDirection(_targetPosition);
            }
            else
            {
                if (_patrolPath.Count > 0)
                {
                    _targetPosition = GetNextPoint();
                    _direction = GetDirection(_targetPosition);
                }
            }

            if (_timer > _timeToChangePoint && IsMoved)
                _direction = Vector3.zero;

            _movable.SetMoveDirection(_direction);
        }

        private void SetPath(NavMeshPath path)
        {
            _patrolPath.Clear();

            if (path.corners.Length > 1)
                for (int i = 1; i < path.corners.Length; i++)
                    _patrolPath.Enqueue(path.corners[i]);
            else
                Debug.Log("No path found");
        }

        private void SetMarkerAtLastPoint(NavMeshPath path)
            => _marker.position = path.corners[path.corners.Length - 1];

        private Vector3 GetRandomPointInRadius()
            => _movable.Transform.position +
               new Vector3(Random.Range(-_radius, _radius), 0, Random.Range(-_radius, _radius));

        private Vector3 GetNextPoint()
            => _patrolPath.Dequeue();

        private Vector3 GetDirection(Vector3 target)
            => (target - _movable.Transform.position).normalized;

        private bool IsReachedTarget(Vector3 target)
            => Vector3.Distance(_movable.Transform.position, target) <= MinDistanceToTarget;
    }
}