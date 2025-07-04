using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class PatrolPlayerController : Controller
    {
        private const float MinDistanceToTarget = 0.1f;

        private IDirectionalMovable _movable;
        private float _timeToChangePoint;
        private float _radius;
        private Queue<Vector3> _patrolPath;
        private Vector3 _targetPosition;
        private Vector3 _direction;

        private NavMeshPath _path;
        private NavMeshQueryFilter _filter;

        private float _timer;

        public PatrolPlayerController(IDirectionalMovable movable, float timeToChangePoint, float radius)
        {
            _movable = movable;
            _timeToChangePoint = timeToChangePoint;
            _radius = radius;
            _path = new NavMeshPath();
            _filter = new NavMeshQueryFilter();
            _filter.areaMask = NavMesh.AllAreas;
            _filter.agentTypeID = 0;
            _patrolPath = new Queue<Vector3>();
            _targetPosition = _movable.Transform.position;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _timer += deltaTime;
            _direction = Vector3.zero;

            if (_timer >= _timeToChangePoint)
            {
                _timer = 0;
                Vector3 point;

                int tryCouter = 50;

                do
                {
                    tryCouter--;
                    point = GetRandomPointInRadius();
                } while (NavMeshUtills.TryGetPath(_movable.Transform.position, point, _filter, _path) == false &&
                         tryCouter != 0);

                if (tryCouter == 0)
                {
                    _targetPosition = _movable.Transform.position;
                    Debug.Log("No path found.You can increase tryCounter");
                }
                else
                {
                    SetPath(_path);
                }
            }

            if (IsReachedTarget(_targetPosition) == false)
                _direction = GetDirection(_targetPosition);
            else
            {
                if (_patrolPath.Count > 0)
                {
                    _targetPosition = GetNextPoint();
                    _direction = GetDirection(_targetPosition);
                }
            }

            _movable.SetMoveDirection(_direction);
        }

        private Vector3 GetRandomPointInRadius()
            => _movable.Transform.position +
               new Vector3(Random.Range(-_radius, _radius), 0, Random.Range(-_radius, _radius));

        private void SetPath(NavMeshPath path)
        {
            _patrolPath.Clear();

            foreach (Vector3 point in path.corners)
                _patrolPath.Enqueue(point);

            _targetPosition = GetNextPoint();
        }

        private Vector3 GetNextPoint()
            => _patrolPath.Dequeue();

        private Vector3 GetDirection(Vector3 target)
            => (target - _movable.Transform.position).normalized;

        private bool IsReachedTarget(Vector3 target)
            => Vector3.Distance(_movable.Transform.position, target) <= MinDistanceToTarget;
    }
}